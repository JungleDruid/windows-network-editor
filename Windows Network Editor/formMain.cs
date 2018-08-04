using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Windows_Network_Editor {
    public partial class formMain : Form {
        private const string NetworkProfilesAddr = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Profiles";
        private const string ManagedSignaturesAddr = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Signatures\Managed";
        private const string UnmanagedSignaturesAddr = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Signatures\Unmanaged";
        private const string NetworkSettingsAddr = @"SOFTWARE\Microsoft\Windows\CurrentVersion\NcdAutoSetup\NetworkSetting";
        private const string ProbeAddr = @"SYSTEM\CurrentControlSet\Services\Dnscache\Parameters\Probe";

        private const string ProfileNameValue = "ProfileName";
        private const string DescriptionValue = "Description";
        private const string ProfileGuidValue = "ProfileGuid";

        public formMain() {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            RefreshNetworkProfiles();
            AcceptButton = buttonEdit;
        }

        private void buttonRefresh_Click(object sender, EventArgs e) {
            RefreshNetworkProfiles();
        }

        private void RefreshNetworkProfiles() {
            ClearSelection();
            var items = listboxNetwork.Items;
            items.Clear();
            using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)) {
                using (var rkey = hklm.OpenSubKey(NetworkProfilesAddr)) {
                    foreach (var name in rkey.GetSubKeyNames()) {
                        using (var profileKey = rkey.OpenSubKey(name)) {
                            items.Add(new NetworkProfile(
                                profileKey.GetValue(ProfileNameValue) as string,
                                profileKey.GetValue(DescriptionValue) as string,
                                name));
                        }
                    }
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e) {
            foreach (var item in listboxNetwork.SelectedItems) {
                var profile = item as NetworkProfile;
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)) {
                    using (var rkey = hklm.OpenSubKey(NetworkProfilesAddr, true)) {
                        rkey.DeleteSubKeyTree(profile.Guid);
                    }

                    using (var rkey = hklm.OpenSubKey(NetworkSettingsAddr, true)) {
                        try {
                            rkey.DeleteSubKeyTree(profile.Guid);
                        } catch { }
                    }

                    using (var rkey = hklm.OpenSubKey(ProbeAddr, true)) {
                        try {
                            rkey.DeleteSubKeyTree(profile.Guid.ToLower());
                        } catch { }
                    }

                    using (var rkey = hklm.OpenSubKey(ManagedSignaturesAddr, true)) {
                        DeleteSubKeyContainsValue(rkey, ProfileGuidValue, profile.Guid);
                    }

                    using (var rkey = hklm.OpenSubKey(UnmanagedSignaturesAddr, true)) {
                        DeleteSubKeyContainsValue(rkey, ProfileGuidValue, profile.Guid);
                    }
                }
            }

            RefreshNetworkProfiles();
        }

        private void DeleteSubKeyContainsValue(RegistryKey registryKey, string valueName, string valueData) {
            string match = null;

            foreach (var name in registryKey.GetSubKeyNames()) {
                using (var rkey = registryKey.OpenSubKey(name)) {
                    string value = rkey.GetValue(valueName) as string;
                    if (value == valueData) {
                        match = name;
                        break;
                    }
                }
            }

            if (match != null) {
                registryKey.DeleteSubKeyTree(match);
            }
        }

        private void listboxNetwork_SelectedIndexChanged(object sender, EventArgs e) {
            if (listboxNetwork.SelectedIndex < 0) {
                ClearSelection();
                return;
            }

            var profile = listboxNetwork.Items[listboxNetwork.SelectedIndex] as NetworkProfile;

            textGuid.Text = profile.Guid;
            textName.Text = profile.Name;
            textDescription.Text = profile.Description;
            textGuid.Enabled = true;
            textName.Enabled = true;
            textDescription.Enabled = true;
            buttonEdit.Enabled = true;
            buttonDelete.Enabled = true;
        }

        private void buttonEdit_Click(object sender, EventArgs e) {
            foreach (var item in listboxNetwork.SelectedItems) {
                var profile = item as NetworkProfile;
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)) {
                    using (var rkey = hklm.OpenSubKey(NetworkProfilesAddr + "\\" + profile.Guid, true)) {
                        rkey.SetValue(ProfileNameValue, textName.Text.Trim());
                        rkey.SetValue(DescriptionValue, textDescription.Text.Trim());
                    }
                }
            }

            RefreshNetworkProfiles();
            listboxNetwork.Focus();
        }

        private void ClearSelection() {
            listboxNetwork.ClearSelected();
            textGuid.Text = "";
            textName.Text = "";
            textDescription.Text = "";
            textGuid.Enabled = false;
            textName.Enabled = false;
            textDescription.Enabled = false;
            buttonEdit.Enabled = false;
            buttonDelete.Enabled = false;
        }

        private bool IsProfileExists(string guid) {
            foreach (var item in listboxNetwork.Items) {
                var profile = item as NetworkProfile;
                if (guid.ToLower() == profile.Guid.ToLower()) {
                    return true;
                }
            }

            return false;
        }

        private void buttonCleanUp_Click(object sender, EventArgs e) {
            RefreshNetworkProfiles();

            using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)) {
                using (var rkey = hklm.OpenSubKey(ProbeAddr, true)) {
                    foreach (var name in rkey.GetSubKeyNames()) {
                        if (IsProfileExists(name)) continue;
                        rkey.DeleteSubKeyTree(name);
                    }
                }

                using (var rkey = hklm.OpenSubKey(ManagedSignaturesAddr, true)) {
                    foreach (var name in rkey.GetSubKeyNames()) {
                        using (var subkey = rkey.OpenSubKey(name)) {
                            if (IsProfileExists(subkey.GetValue(ProfileGuidValue) as string)) continue;
                        }

                        rkey.DeleteSubKeyTree(name);
                    }
                }

                using (var rkey = hklm.OpenSubKey(UnmanagedSignaturesAddr, true)) {
                    foreach (var name in rkey.GetSubKeyNames()) {
                        using (var subkey = rkey.OpenSubKey(name)) {
                            if (IsProfileExists(subkey.GetValue(ProfileGuidValue) as string)) continue;
                        }

                        rkey.DeleteSubKeyTree(name);
                    }
                }
            }

            RefreshNetworkProfiles();
        }
    }
}
