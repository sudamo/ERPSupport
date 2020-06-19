namespace ERPSupport.SupForm.UserCrtl
{
    partial class ucSM_UserAcc
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSM_UserAcc));
            this.lblTitle = new System.Windows.Forms.Label();
            this.pl1 = new System.Windows.Forms.Panel();
            this.pl3 = new System.Windows.Forms.Panel();
            this.chbOccupy = new System.Windows.Forms.CheckBox();
            this.chbExport = new System.Windows.Forms.CheckBox();
            this.chbImport = new System.Windows.Forms.CheckBox();
            this.chbTimerPick = new System.Windows.Forms.CheckBox();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.trv1 = new System.Windows.Forms.TreeView();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblUserList = new System.Windows.Forms.Label();
            this.pl1.SuspendLayout();
            this.pl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(660, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "权限管理";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pl1
            // 
            this.pl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pl1.Controls.Add(this.pl3);
            this.pl1.Controls.Add(this.lblPrompt);
            this.pl1.Controls.Add(this.txtRoleName);
            this.pl1.Controls.Add(this.trv1);
            this.pl1.Controls.Add(this.dgv1);
            this.pl1.Controls.Add(this.btnAdd);
            this.pl1.Controls.Add(this.btnSave);
            this.pl1.Controls.Add(this.btnDelete);
            this.pl1.Location = new System.Drawing.Point(3, 38);
            this.pl1.Name = "pl1";
            this.pl1.Size = new System.Drawing.Size(494, 499);
            this.pl1.TabIndex = 1;
            // 
            // pl3
            // 
            this.pl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pl3.Controls.Add(this.chbOccupy);
            this.pl3.Controls.Add(this.chbExport);
            this.pl3.Controls.Add(this.chbImport);
            this.pl3.Controls.Add(this.chbTimerPick);
            this.pl3.Location = new System.Drawing.Point(384, 28);
            this.pl3.Name = "pl3";
            this.pl3.Size = new System.Drawing.Size(107, 460);
            this.pl3.TabIndex = 5;
            // 
            // chbOccupy
            // 
            this.chbOccupy.AutoSize = true;
            this.chbOccupy.Location = new System.Drawing.Point(3, 3);
            this.chbOccupy.Name = "chbOccupy";
            this.chbOccupy.Size = new System.Drawing.Size(72, 16);
            this.chbOccupy.TabIndex = 0;
            this.chbOccupy.Text = "占用解除";
            this.chbOccupy.UseVisualStyleBackColor = true;
            // 
            // chbExport
            // 
            this.chbExport.AutoSize = true;
            this.chbExport.Enabled = false;
            this.chbExport.Location = new System.Drawing.Point(3, 139);
            this.chbExport.Name = "chbExport";
            this.chbExport.Size = new System.Drawing.Size(72, 16);
            this.chbExport.TabIndex = 3;
            this.chbExport.Text = "导出报表";
            this.chbExport.UseVisualStyleBackColor = true;
            // 
            // chbImport
            // 
            this.chbImport.AutoSize = true;
            this.chbImport.Enabled = false;
            this.chbImport.Location = new System.Drawing.Point(3, 117);
            this.chbImport.Name = "chbImport";
            this.chbImport.Size = new System.Drawing.Size(72, 16);
            this.chbImport.TabIndex = 2;
            this.chbImport.Text = "导入报表";
            this.chbImport.UseVisualStyleBackColor = true;
            // 
            // chbTimerPick
            // 
            this.chbTimerPick.AutoSize = true;
            this.chbTimerPick.Location = new System.Drawing.Point(3, 25);
            this.chbTimerPick.Name = "chbTimerPick";
            this.chbTimerPick.Size = new System.Drawing.Size(72, 16);
            this.chbTimerPick.TabIndex = 1;
            this.chbTimerPick.Text = "定时领料";
            this.chbTimerPick.UseVisualStyleBackColor = true;
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.ForeColor = System.Drawing.Color.Red;
            this.lblPrompt.Location = new System.Drawing.Point(200, 8);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(0, 12);
            this.lblPrompt.TabIndex = 3;
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(3, 5);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(110, 21);
            this.txtRoleName.TabIndex = 0;
            // 
            // trv1
            // 
            this.trv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trv1.Location = new System.Drawing.Point(118, 28);
            this.trv1.Name = "trv1";
            this.trv1.Size = new System.Drawing.Size(260, 460);
            this.trv1.TabIndex = 5;
            this.trv1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trv1_AfterCheck);
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToResizeColumns = false;
            this.dgv1.AllowUserToResizeRows = false;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(3, 28);
            this.dgv1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv1.RowTemplate.Height = 27;
            this.dgv1.ShowEditingIcon = false;
            this.dgv1.Size = new System.Drawing.Size(110, 460);
            this.dgv1.TabIndex = 2;
            this.dgv1.Click += new System.EventHandler(this.dgv1_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(118, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "创建角色";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(335, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存方案";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(416, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除方案";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "activity_monitor.png");
            this.imageList1.Images.SetKeyName(1, "activity_monitor_add.png");
            this.imageList1.Images.SetKeyName(2, "activity_monitor_chart.png");
            this.imageList1.Images.SetKeyName(3, "activity_monitor_close.png");
            this.imageList1.Images.SetKeyName(4, "activity_monitor_warning.png");
            this.imageList1.Images.SetKeyName(5, "add_16.png");
            this.imageList1.Images.SetKeyName(6, "add_32.png");
            this.imageList1.Images.SetKeyName(7, "address_book_32.png");
            this.imageList1.Images.SetKeyName(8, "address_book_add_32.png");
            this.imageList1.Images.SetKeyName(9, "address_book_close_32.png");
            this.imageList1.Images.SetKeyName(10, "address_book_search_32.png");
            this.imageList1.Images.SetKeyName(11, "address_book_warning_32.png");
            this.imageList1.Images.SetKeyName(12, "arrow_down_16.png");
            this.imageList1.Images.SetKeyName(13, "arrow_down_32.png");
            this.imageList1.Images.SetKeyName(14, "arrow_left_16.png");
            this.imageList1.Images.SetKeyName(15, "arrow_left_32.png");
            this.imageList1.Images.SetKeyName(16, "arrow_right_16.png");
            this.imageList1.Images.SetKeyName(17, "arrow_right_32.png");
            this.imageList1.Images.SetKeyName(18, "arrow_up_16.png");
            this.imageList1.Images.SetKeyName(19, "arrow_up_32.png");
            this.imageList1.Images.SetKeyName(20, "basket_32.png");
            this.imageList1.Images.SetKeyName(21, "basket_add_32.png");
            this.imageList1.Images.SetKeyName(22, "basket_back_32.png");
            this.imageList1.Images.SetKeyName(23, "basket_chart_32.png");
            this.imageList1.Images.SetKeyName(24, "basket_close_32.png");
            this.imageList1.Images.SetKeyName(25, "basket_go_32.png");
            this.imageList1.Images.SetKeyName(26, "basket_search_32.png");
            this.imageList1.Images.SetKeyName(27, "blue_arrow_down_32.png");
            this.imageList1.Images.SetKeyName(28, "blue_arrow_left_32.png");
            this.imageList1.Images.SetKeyName(29, "blue_arrow_right_32.png");
            this.imageList1.Images.SetKeyName(30, "blue_arrow_up_32.png");
            this.imageList1.Images.SetKeyName(31, "book_32.png");
            this.imageList1.Images.SetKeyName(32, "book_add_32.png");
            this.imageList1.Images.SetKeyName(33, "book_bookmarks_32.png");
            this.imageList1.Images.SetKeyName(34, "book_close_32.png");
            this.imageList1.Images.SetKeyName(35, "book_search_32.png");
            this.imageList1.Images.SetKeyName(36, "book_warning_32.png");
            this.imageList1.Images.SetKeyName(37, "camera_32.png");
            this.imageList1.Images.SetKeyName(38, "camera_add_32.png");
            this.imageList1.Images.SetKeyName(39, "camera_close_32.png");
            this.imageList1.Images.SetKeyName(40, "chart_16.png");
            this.imageList1.Images.SetKeyName(41, "chart_32.png");
            this.imageList1.Images.SetKeyName(42, "chart_flipped_16.png");
            this.imageList1.Images.SetKeyName(43, "chart_flipped_32.png");
            this.imageList1.Images.SetKeyName(44, "clock_32.png");
            this.imageList1.Images.SetKeyName(45, "close_16.png");
            this.imageList1.Images.SetKeyName(46, "close_32.png");
            this.imageList1.Images.SetKeyName(47, "comment_32.png");
            this.imageList1.Images.SetKeyName(48, "comment_add_32.png");
            this.imageList1.Images.SetKeyName(49, "comment_page_32.png");
            this.imageList1.Images.SetKeyName(50, "comment_user_32.png");
            this.imageList1.Images.SetKeyName(51, "comment_user_add_32.png");
            this.imageList1.Images.SetKeyName(52, "comment_user_chart_32.png");
            this.imageList1.Images.SetKeyName(53, "comment_user_close_32.png");
            this.imageList1.Images.SetKeyName(54, "comment_user_info_32.png");
            this.imageList1.Images.SetKeyName(55, "comment_user_page_32.png");
            this.imageList1.Images.SetKeyName(56, "comment_user_rss_32.png");
            this.imageList1.Images.SetKeyName(57, "comment_user_search_32.png");
            this.imageList1.Images.SetKeyName(58, "comment_user_warning_32.png");
            this.imageList1.Images.SetKeyName(59, "database_32.png");
            this.imageList1.Images.SetKeyName(60, "database_add_32.png");
            this.imageList1.Images.SetKeyName(61, "database_chart_32.png");
            this.imageList1.Images.SetKeyName(62, "database_close_32.png");
            this.imageList1.Images.SetKeyName(63, "database_page_32.png");
            this.imageList1.Images.SetKeyName(64, "database_search_32.png");
            this.imageList1.Images.SetKeyName(65, "database_warning_32.png");
            this.imageList1.Images.SetKeyName(66, "email_32.png");
            this.imageList1.Images.SetKeyName(67, "email_add_32.png");
            this.imageList1.Images.SetKeyName(68, "email_close_32.png");
            this.imageList1.Images.SetKeyName(69, "email_forward_32.png");
            this.imageList1.Images.SetKeyName(70, "email_reply_32.png");
            this.imageList1.Images.SetKeyName(71, "email_reply_all_32.png");
            this.imageList1.Images.SetKeyName(72, "error_button.png");
            this.imageList1.Images.SetKeyName(73, "error_button_16.png");
            this.imageList1.Images.SetKeyName(74, "folder_32.png");
            this.imageList1.Images.SetKeyName(75, "folder_add_32.png");
            this.imageList1.Images.SetKeyName(76, "folder_chart_32.png");
            this.imageList1.Images.SetKeyName(77, "folder_close_32.png");
            this.imageList1.Images.SetKeyName(78, "folder_page_32.png");
            this.imageList1.Images.SetKeyName(79, "folder_search_32.png");
            this.imageList1.Images.SetKeyName(80, "folder_warning_32.png");
            this.imageList1.Images.SetKeyName(81, "hammer_32.png");
            this.imageList1.Images.SetKeyName(82, "heart_16.png");
            this.imageList1.Images.SetKeyName(83, "heart_32.png");
            this.imageList1.Images.SetKeyName(84, "home_32.png");
            this.imageList1.Images.SetKeyName(85, "home_back_32.png");
            this.imageList1.Images.SetKeyName(86, "home_go_32.png");
            this.imageList1.Images.SetKeyName(87, "info_button_16.png");
            this.imageList1.Images.SetKeyName(88, "info_button_32.png");
            this.imageList1.Images.SetKeyName(89, "lightbulb_32.png");
            this.imageList1.Images.SetKeyName(90, "lightbulb_off_32.png");
            this.imageList1.Images.SetKeyName(91, "lock_32.png");
            this.imageList1.Images.SetKeyName(92, "lock_open_32.png");
            this.imageList1.Images.SetKeyName(93, "newspaper_32.png");
            this.imageList1.Images.SetKeyName(94, "newspaper_add_32.png");
            this.imageList1.Images.SetKeyName(95, "newspaper_close_32.png");
            this.imageList1.Images.SetKeyName(96, "newspaper_info_32.png");
            this.imageList1.Images.SetKeyName(97, "newspaper_rss_32.png");
            this.imageList1.Images.SetKeyName(98, "newspaper_search_32.png");
            this.imageList1.Images.SetKeyName(99, "page_16.png");
            this.imageList1.Images.SetKeyName(100, "page_blank_32.png");
            this.imageList1.Images.SetKeyName(101, "page_blank_add_32.png");
            this.imageList1.Images.SetKeyName(102, "page_blank_chart_32.png");
            this.imageList1.Images.SetKeyName(103, "page_blank_close_32.png");
            this.imageList1.Images.SetKeyName(104, "page_blank_warning_32.png");
            this.imageList1.Images.SetKeyName(105, "page_table_32.png");
            this.imageList1.Images.SetKeyName(106, "page_table_add_32.png");
            this.imageList1.Images.SetKeyName(107, "page_table_chart_32.png");
            this.imageList1.Images.SetKeyName(108, "page_table_close_32.png");
            this.imageList1.Images.SetKeyName(109, "page_table_warning_32.png");
            this.imageList1.Images.SetKeyName(110, "page_text_32.png");
            this.imageList1.Images.SetKeyName(111, "page_text_add_32.png");
            this.imageList1.Images.SetKeyName(112, "page_text_chart_32.png");
            this.imageList1.Images.SetKeyName(113, "page_text_close_32.png");
            this.imageList1.Images.SetKeyName(114, "page_text_warning_32.png");
            this.imageList1.Images.SetKeyName(115, "pencil_32.png");
            this.imageList1.Images.SetKeyName(116, "rss_16.png");
            this.imageList1.Images.SetKeyName(117, "rss_32.png");
            this.imageList1.Images.SetKeyName(118, "save_32.png");
            this.imageList1.Images.SetKeyName(119, "save_download_32.png");
            this.imageList1.Images.SetKeyName(120, "save_upload_32.png");
            this.imageList1.Images.SetKeyName(121, "screen_32.png");
            this.imageList1.Images.SetKeyName(122, "screen_off_32.png");
            this.imageList1.Images.SetKeyName(123, "screwdriver_32.png");
            this.imageList1.Images.SetKeyName(124, "search_32.png");
            this.imageList1.Images.SetKeyName(125, "search_button_16.png");
            this.imageList1.Images.SetKeyName(126, "search_button_32.png");
            this.imageList1.Images.SetKeyName(127, "search_button_green_16.png");
            this.imageList1.Images.SetKeyName(128, "search_button_green_32.png");
            this.imageList1.Images.SetKeyName(129, "search_chart_32.png");
            this.imageList1.Images.SetKeyName(130, "search_warning_32.png");
            this.imageList1.Images.SetKeyName(131, "star_16.png");
            this.imageList1.Images.SetKeyName(132, "star_32.png");
            this.imageList1.Images.SetKeyName(133, "star_off_32.png");
            this.imageList1.Images.SetKeyName(134, "star_off16.png");
            this.imageList1.Images.SetKeyName(135, "tools_32.png");
            this.imageList1.Images.SetKeyName(136, "twitter_16.png");
            this.imageList1.Images.SetKeyName(137, "twitter_32.png");
            this.imageList1.Images.SetKeyName(138, "user_32.png");
            this.imageList1.Images.SetKeyName(139, "user_add_32.png");
            this.imageList1.Images.SetKeyName(140, "user_blue_32.png");
            this.imageList1.Images.SetKeyName(141, "user_business_32.png");
            this.imageList1.Images.SetKeyName(142, "user_business_add_32.png");
            this.imageList1.Images.SetKeyName(143, "user_business_chart_32.png");
            this.imageList1.Images.SetKeyName(144, "user_business_close_32.png");
            this.imageList1.Images.SetKeyName(145, "user_business_info_32.png");
            this.imageList1.Images.SetKeyName(146, "user_business_rss_32.png");
            this.imageList1.Images.SetKeyName(147, "user_business_search_32.png");
            this.imageList1.Images.SetKeyName(148, "user_business_twitter_32.png");
            this.imageList1.Images.SetKeyName(149, "user_business_warning_32.png");
            this.imageList1.Images.SetKeyName(150, "user_close_32.png");
            this.imageList1.Images.SetKeyName(151, "user_info_32.png");
            this.imageList1.Images.SetKeyName(152, "user_rss_32.png");
            this.imageList1.Images.SetKeyName(153, "user_search_32.png");
            this.imageList1.Images.SetKeyName(154, "user_twitter_32.png");
            this.imageList1.Images.SetKeyName(155, "user_warning_32.png");
            this.imageList1.Images.SetKeyName(156, "users_32.png");
            this.imageList1.Images.SetKeyName(157, "users_business_32.png");
            this.imageList1.Images.SetKeyName(158, "warning_16.png");
            this.imageList1.Images.SetKeyName(159, "warning_32.png");
            this.imageList1.Images.SetKeyName(160, "web_layout_32.png");
            this.imageList1.Images.SetKeyName(161, "web_layout_chart_32.png");
            this.imageList1.Images.SetKeyName(162, "web_layout_error_32.png");
            this.imageList1.Images.SetKeyName(163, "web_layout_error_32_add.png");
            this.imageList1.Images.SetKeyName(164, "web_layout_error_32_close.png");
            this.imageList1.Images.SetKeyName(165, "web_layout_info_32.png");
            this.imageList1.Images.SetKeyName(166, "web_layout_rss_32.png");
            this.imageList1.Images.SetKeyName(167, "web_layout_search_32.png");
            this.imageList1.Images.SetKeyName(168, "web_layout_twitter_32.png");
            this.imageList1.Images.SetKeyName(169, "window_app_32.png");
            this.imageList1.Images.SetKeyName(170, "window_app_blank_32.png");
            this.imageList1.Images.SetKeyName(171, "window_app_list_32.png");
            this.imageList1.Images.SetKeyName(172, "window_app_list_add_32.png");
            this.imageList1.Images.SetKeyName(173, "window_app_list_chart_32.png");
            this.imageList1.Images.SetKeyName(174, "window_app_list_close_32.png");
            this.imageList1.Images.SetKeyName(175, "window_app_list_error_32.png");
            this.imageList1.Images.SetKeyName(176, "window_app_list_info_32.png");
            this.imageList1.Images.SetKeyName(177, "window_app_list_search_32.png");
            // 
            // lblUserList
            // 
            this.lblUserList.AutoSize = true;
            this.lblUserList.Font = new System.Drawing.Font("宋体", 10F);
            this.lblUserList.Location = new System.Drawing.Point(500, 66);
            this.lblUserList.Name = "lblUserList";
            this.lblUserList.Size = new System.Drawing.Size(77, 14);
            this.lblUserList.TabIndex = 2;
            this.lblUserList.Text = "分配用户：";
            // 
            // ucSM_UserAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblUserList);
            this.Controls.Add(this.pl1);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucSM_UserAcc";
            this.Size = new System.Drawing.Size(660, 540);
            this.Load += new System.EventHandler(this.ucMS_UserAcc_Load);
            this.pl1.ResumeLayout(false);
            this.pl1.PerformLayout();
            this.pl3.ResumeLayout(false);
            this.pl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pl1;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TreeView trv1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblUserList;
        private System.Windows.Forms.CheckBox chbTimerPick;
        private System.Windows.Forms.CheckBox chbOccupy;
        private System.Windows.Forms.Panel pl3;
        private System.Windows.Forms.CheckBox chbExport;
        private System.Windows.Forms.CheckBox chbImport;
    }
}
