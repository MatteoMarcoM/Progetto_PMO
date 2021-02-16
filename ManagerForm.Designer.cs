
namespace PasswordManager
{
    partial class ManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.genPassLabel = new System.Windows.Forms.Label();
            this.textBoxPassLength = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.textBoxRandPass = new System.Windows.Forms.TextBox();
            this.RegAccountLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.passLabel = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.passSearchLabel = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.textBoxPassSearch = new System.Windows.Forms.TextBox();
            this.textBoxUserSearch = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.listViewUserPass = new System.Windows.Forms.ListView();
            this.columnHeaderUser = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderPass = new System.Windows.Forms.ColumnHeader();
            this.removeButton = new System.Windows.Forms.Button();
            this.LogoutLabel = new System.Windows.Forms.Label();
            this.textBoxUserLogged = new System.Windows.Forms.TextBox();
            this.LogoutButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.genPassLabel);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxPassLength);
            this.splitContainer1.Panel1.Controls.Add(this.generateButton);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxRandPass);
            this.splitContainer1.Panel1.Controls.Add(this.RegAccountLabel);
            this.splitContainer1.Panel1.Controls.Add(this.addButton);
            this.splitContainer1.Panel1.Controls.Add(this.passLabel);
            this.splitContainer1.Panel1.Controls.Add(this.userLabel);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxPass);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxUser);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.passSearchLabel);
            this.splitContainer1.Panel2.Controls.Add(this.searchButton);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxPassSearch);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxUserSearch);
            this.splitContainer1.Panel2.Controls.Add(this.saveButton);
            this.splitContainer1.Panel2.Controls.Add(this.listViewUserPass);
            this.splitContainer1.Panel2.Controls.Add(this.removeButton);
            // 
            // genPassLabel
            // 
            resources.ApplyResources(this.genPassLabel, "genPassLabel");
            this.genPassLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.genPassLabel.Name = "genPassLabel";
            // 
            // textBoxPassLength
            // 
            resources.ApplyResources(this.textBoxPassLength, "textBoxPassLength");
            this.textBoxPassLength.Name = "textBoxPassLength";
            this.textBoxPassLength.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBox_MouseClick);
            // 
            // generateButton
            // 
            resources.ApplyResources(this.generateButton, "generateButton");
            this.generateButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.generateButton.Name = "generateButton";
            this.generateButton.UseVisualStyleBackColor = false;
            this.generateButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GenerateB_clicked);
            // 
            // textBoxRandPass
            // 
            resources.ApplyResources(this.textBoxRandPass, "textBoxRandPass");
            this.textBoxRandPass.Name = "textBoxRandPass";
            this.textBoxRandPass.ReadOnly = true;
            // 
            // RegAccountLabel
            // 
            resources.ApplyResources(this.RegAccountLabel, "RegAccountLabel");
            this.RegAccountLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.RegAccountLabel.Name = "RegAccountLabel";
            // 
            // addButton
            // 
            resources.ApplyResources(this.addButton, "addButton");
            this.addButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.addButton.Name = "addButton";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.AddB_clicked);
            // 
            // passLabel
            // 
            resources.ApplyResources(this.passLabel, "passLabel");
            this.passLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.passLabel.Name = "passLabel";
            // 
            // userLabel
            // 
            resources.ApplyResources(this.userLabel, "userLabel");
            this.userLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.userLabel.Name = "userLabel";
            // 
            // textBoxPass
            // 
            resources.ApplyResources(this.textBoxPass, "textBoxPass");
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.UseSystemPasswordChar = true;
            this.textBoxPass.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextBox_MouseClick);
            // 
            // textBoxUser
            // 
            resources.ApplyResources(this.textBoxUser, "textBoxUser");
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextBox_MouseClick);
            // 
            // passSearchLabel
            // 
            resources.ApplyResources(this.passSearchLabel, "passSearchLabel");
            this.passSearchLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.passSearchLabel.Name = "passSearchLabel";
            // 
            // searchButton
            // 
            resources.ApplyResources(this.searchButton, "searchButton");
            this.searchButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.searchButton.Name = "searchButton";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.SearchB_clicked);
            // 
            // textBoxPassSearch
            // 
            resources.ApplyResources(this.textBoxPassSearch, "textBoxPassSearch");
            this.textBoxPassSearch.Name = "textBoxPassSearch";
            this.textBoxPassSearch.ReadOnly = true;
            // 
            // textBoxUserSearch
            // 
            resources.ApplyResources(this.textBoxUserSearch, "textBoxUserSearch");
            this.textBoxUserSearch.Name = "textBoxUserSearch";
            this.textBoxUserSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBox_MouseClick);
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.SaveB_clicked);
            // 
            // listViewUserPass
            // 
            resources.ApplyResources(this.listViewUserPass, "listViewUserPass");
            this.listViewUserPass.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listViewUserPass.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderUser,
            this.columnHeaderPass});
            this.listViewUserPass.FullRowSelect = true;
            this.listViewUserPass.GridLines = true;
            this.listViewUserPass.HideSelection = false;
            this.listViewUserPass.MultiSelect = false;
            this.listViewUserPass.Name = "listViewUserPass";
            this.listViewUserPass.UseCompatibleStateImageBehavior = false;
            this.listViewUserPass.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderUser
            // 
            resources.ApplyResources(this.columnHeaderUser, "columnHeaderUser");
            // 
            // columnHeaderPass
            // 
            resources.ApplyResources(this.columnHeaderPass, "columnHeaderPass");
            // 
            // removeButton
            // 
            resources.ApplyResources(this.removeButton, "removeButton");
            this.removeButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.removeButton.Name = "removeButton";
            this.removeButton.UseVisualStyleBackColor = false;
            this.removeButton.Click += new System.EventHandler(this.RemoveB_clicked);
            // 
            // LogoutLabel
            // 
            resources.ApplyResources(this.LogoutLabel, "LogoutLabel");
            this.LogoutLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.LogoutLabel.Name = "LogoutLabel";
            // 
            // textBoxUserLogged
            // 
            resources.ApplyResources(this.textBoxUserLogged, "textBoxUserLogged");
            this.textBoxUserLogged.Name = "textBoxUserLogged";
            this.textBoxUserLogged.ReadOnly = true;
            // 
            // LogoutButton
            // 
            resources.ApplyResources(this.LogoutButton, "LogoutButton");
            this.LogoutButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.UseVisualStyleBackColor = false;
            this.LogoutButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LogoutB_clicked);
            // 
            // ManagerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.textBoxUserLogged);
            this.Controls.Add(this.LogoutLabel);
            this.Controls.Add(this.splitContainer1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ManagerForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listViewUserPass;
        private System.Windows.Forms.ColumnHeader columnHeaderUser;
        private System.Windows.Forms.ColumnHeader columnHeaderPass;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label RegAccountLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TextBox textBoxRandPass;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox textBoxPassSearch;
        private System.Windows.Forms.TextBox textBoxUserSearch;
        private System.Windows.Forms.Label passSearchLabel;
        private System.Windows.Forms.Label genPassLabel;
        private System.Windows.Forms.TextBox textBoxPassLength;
        private System.Windows.Forms.Label LogoutLabel;
        private System.Windows.Forms.TextBox textBoxUserLogged;
        private System.Windows.Forms.Button LogoutButton;
    }
}