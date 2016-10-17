namespace CCTanks
{
    partial class ControllerMainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControllerMainForm));
            this.StartStop_pcbx = new System.Windows.Forms.PictureBox();
            this.Help_t_tip = new System.Windows.Forms.ToolTip(this.components);
            this.MainMenu_strp = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.srttingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.GameStatus_lbl_ststrp = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.StartStop_pcbx)).BeginInit();
            this.MainMenu_strp.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartStop_pcbx
            // 
            this.StartStop_pcbx.Image = global::CCTanks.Properties.Resources.ppp1play1;
            this.StartStop_pcbx.Location = new System.Drawing.Point(282, 108);
            this.StartStop_pcbx.Name = "StartStop_pcbx";
            this.StartStop_pcbx.Size = new System.Drawing.Size(90, 90);
            this.StartStop_pcbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.StartStop_pcbx.TabIndex = 1;
            this.StartStop_pcbx.TabStop = false;
            this.Help_t_tip.SetToolTip(this.StartStop_pcbx, "Click button to START GAME");
            this.StartStop_pcbx.Click += new System.EventHandler(this.StartPause_btn_Click);
            this.StartStop_pcbx.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Manipulation_pcbx_PreviewKeyDown);
            // 
            // Help_t_tip
            // 
            this.Help_t_tip.IsBalloon = true;
            this.Help_t_tip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.Help_t_tip.ToolTipTitle = "Танки 1.0";
            // 
            // MainMenu_strp
            // 
            this.MainMenu_strp.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.MainMenu_strp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem1,
            this.settingToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.MainMenu_strp.Location = new System.Drawing.Point(0, 0);
            this.MainMenu_strp.Name = "MainMenu_strp";
            this.MainMenu_strp.Size = new System.Drawing.Size(384, 24);
            this.MainMenu_strp.TabIndex = 2;
            this.MainMenu_strp.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem1
            // 
            this.gameToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem1,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem1});
            this.gameToolStripMenuItem1.Image = global::CCTanks.Properties.Resources.PLAY;
            this.gameToolStripMenuItem1.Name = "gameToolStripMenuItem1";
            this.gameToolStripMenuItem1.Size = new System.Drawing.Size(66, 20);
            this.gameToolStripMenuItem1.Text = "&Game";
            // 
            // newGameToolStripMenuItem1
            // 
            this.newGameToolStripMenuItem1.Image = global::CCTanks.Properties.Resources.PLAY_2;
            this.newGameToolStripMenuItem1.Name = "newGameToolStripMenuItem1";
            this.newGameToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.newGameToolStripMenuItem1.Text = "&New Game";
            this.newGameToolStripMenuItem1.Click += new System.EventHandler(this.NewGameToolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(129, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Image = global::CCTanks.Properties.Resources.EXIT;
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem1.Text = "&Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ExitToolStripMenuItem1_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.soundToolStripMenuItem1});
            this.settingToolStripMenuItem.Image = global::CCTanks.Properties.Resources.SET;
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.settingToolStripMenuItem.Text = "&Setting";
            // 
            // soundToolStripMenuItem1
            // 
            this.soundToolStripMenuItem1.Image = global::CCTanks.Properties.Resources.NOsound;
            this.soundToolStripMenuItem1.Name = "soundToolStripMenuItem1";
            this.soundToolStripMenuItem1.Size = new System.Drawing.Size(108, 22);
            this.soundToolStripMenuItem1.Text = "&Sound";
            this.soundToolStripMenuItem1.Click += new System.EventHandler(this.soundToolStripMenuItem1_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.infoToolStripMenuItem.Image = global::CCTanks.Properties.Resources.INFO;
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.infoToolStripMenuItem.Text = "&Info";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::CCTanks.Properties.Resources.INFO_2;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "&Game";
            // 
            // srttingToolStripMenuItem
            // 
            this.srttingToolStripMenuItem.Name = "srttingToolStripMenuItem";
            this.srttingToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.srttingToolStripMenuItem.Text = "&Settings";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newGameToolStripMenuItem.Text = "&New Game";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            // 
            // soundToolStripMenuItem
            // 
            this.soundToolStripMenuItem.Name = "soundToolStripMenuItem";
            this.soundToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.soundToolStripMenuItem.Text = "&Sound";
            // 
            // informationToolStripMenuItem
            // 
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            this.informationToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.informationToolStripMenuItem.Text = "&Info";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GameStatus_lbl_ststrp});
            this.statusStrip1.Location = new System.Drawing.Point(0, 340);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(384, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // GameStatus_lbl_ststrp
            // 
            this.GameStatus_lbl_ststrp.BackColor = System.Drawing.SystemColors.Info;
            this.GameStatus_lbl_ststrp.Name = "GameStatus_lbl_ststrp";
            this.GameStatus_lbl_ststrp.Size = new System.Drawing.Size(0, 17);
            // 
            // ControllerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(384, 362);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.StartStop_pcbx);
            this.Controls.Add(this.MainMenu_strp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu_strp;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 400);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "ControllerMainForm";
            this.Text = "Танки - © Alexey";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Controller_MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.StartStop_pcbx)).EndInit();
            this.MainMenu_strp.ResumeLayout(false);
            this.MainMenu_strp.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox StartStop_pcbx;
        private System.Windows.Forms.ToolTip Help_t_tip;
        private System.Windows.Forms.MenuStrip MainMenu_strp;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem srttingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soundToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel GameStatus_lbl_ststrp;


    }
}

