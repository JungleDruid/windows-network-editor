namespace Windows_Network_Editor {
    partial class formMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.listboxNetwork = new System.Windows.Forms.ListBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelProfileName = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelGuid = new System.Windows.Forms.Label();
            this.textGuid = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.textDescription = new System.Windows.Forms.TextBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonCleanUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listboxNetwork
            // 
            this.listboxNetwork.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listboxNetwork.FormattingEnabled = true;
            this.listboxNetwork.Location = new System.Drawing.Point(0, 26);
            this.listboxNetwork.Name = "listboxNetwork";
            this.listboxNetwork.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listboxNetwork.Size = new System.Drawing.Size(246, 186);
            this.listboxNetwork.TabIndex = 0;
            this.listboxNetwork.SelectedIndexChanged += new System.EventHandler(this.listboxNetwork_SelectedIndexChanged);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(0, 0);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(246, 26);
            this.buttonRefresh.TabIndex = 6;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(323, 173);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(123, 30);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelProfileName
            // 
            this.labelProfileName.AutoSize = true;
            this.labelProfileName.Location = new System.Drawing.Point(250, 62);
            this.labelProfileName.Name = "labelProfileName";
            this.labelProfileName.Size = new System.Drawing.Size(67, 13);
            this.labelProfileName.TabIndex = 3;
            this.labelProfileName.Text = "Profile Name";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(250, 88);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Description";
            // 
            // labelGuid
            // 
            this.labelGuid.AutoSize = true;
            this.labelGuid.Location = new System.Drawing.Point(250, 36);
            this.labelGuid.Name = "labelGuid";
            this.labelGuid.Size = new System.Drawing.Size(29, 13);
            this.labelGuid.TabIndex = 5;
            this.labelGuid.Text = "Guid";
            // 
            // textGuid
            // 
            this.textGuid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textGuid.Enabled = false;
            this.textGuid.Location = new System.Drawing.Point(323, 36);
            this.textGuid.Name = "textGuid";
            this.textGuid.ReadOnly = true;
            this.textGuid.Size = new System.Drawing.Size(235, 20);
            this.textGuid.TabIndex = 1;
            // 
            // textName
            // 
            this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textName.Enabled = false;
            this.textName.Location = new System.Drawing.Point(323, 62);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(235, 20);
            this.textName.TabIndex = 2;
            // 
            // textDescription
            // 
            this.textDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textDescription.Enabled = false;
            this.textDescription.Location = new System.Drawing.Point(323, 88);
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(235, 20);
            this.textDescription.TabIndex = 3;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Enabled = false;
            this.buttonEdit.Location = new System.Drawing.Point(323, 127);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(123, 31);
            this.buttonEdit.TabIndex = 4;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonCleanUp
            // 
            this.buttonCleanUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCleanUp.Location = new System.Drawing.Point(456, 2);
            this.buttonCleanUp.Name = "buttonCleanUp";
            this.buttonCleanUp.Size = new System.Drawing.Size(112, 22);
            this.buttonCleanUp.TabIndex = 7;
            this.buttonCleanUp.Text = "Registry Clean Up";
            this.buttonCleanUp.UseVisualStyleBackColor = true;
            this.buttonCleanUp.Click += new System.EventHandler(this.buttonCleanUp_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 215);
            this.Controls.Add(this.buttonCleanUp);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.textDescription);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.textGuid);
            this.Controls.Add(this.labelGuid);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelProfileName);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.listboxNetwork);
            this.MaximizeBox = false;
            this.Name = "formMain";
            this.Text = "Windows Network Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listboxNetwork;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelProfileName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelGuid;
        private System.Windows.Forms.TextBox textGuid;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.TextBox textDescription;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonCleanUp;
    }
}

