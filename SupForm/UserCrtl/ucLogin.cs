﻿using System;
using System.Windows.Forms;

namespace ERPSupport.SupForm.UserCrtl
{
    /// <summary>
    /// 用户登陆窗
    /// </summary>
    public partial class ucLogin : UserControl
    {
        /// <summary>
        /// 委托BTN
        /// </summary>
        public event EventHandler pLoginClick;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ucLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// btnLogin_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //if (pLoginClick != null)
            //{
            //    pLoginClick(sender, e);
            //}
            pLoginClick?.Invoke(sender, e);
        }

        /// <summary>
        /// btnExit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// txtUser_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPWD.SelectAll();
                txtPWD.Focus();
            }
        }

        /// <summary>
        /// txtPWD_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPWD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin_Click(sender, null);
            }
        }
    }
}
