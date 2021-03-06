﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITCLib;

namespace ISISFrontEnd
{
    public partial class GroupList : Form
    {
        public MainMenu frmParent;
        public string key;

        private List<SurveyUserGroup> groups;
        private BindingSource bs;

        public GroupList()
        {
            InitializeComponent();

            groups = DBAction.GetGroupInfo();

            bs = new BindingSource
            {
                DataSource = groups
            };
            navGroup.BindingSource = bs;


            txtID.DataBindings.Add("Text", bs, "ID");
            txtGroup.DataBindings.Add("Text", bs, "UserGroup");
            txtCode.DataBindings.Add("Text", bs, "Code");
            txtWebName.DataBindings.Add("Text", bs, "WebName");
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CohortList_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmParent.CloseTab(key);
        }
    }
}
