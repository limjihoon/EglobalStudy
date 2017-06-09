﻿using Manager_proj_4;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ModernUIApp1
{
	/// <summary>
	/// Cofile.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class Cofile : UserControl
	{
		public Cofile()
		{
			InitializeComponent();
			InitLinuxDirectory();
		}

		#region Cofile
		string root_path = AppDomain.CurrentDomain.BaseDirectory;
		void InitLinuxDirectory()
		{
			textBox_linux_directory_filter.TextChanged += delegate { LinuxTreeViewItem.Filter_string = textBox_linux_directory_filter.Text; };

			// BackgroundWorker의 이벤트 처리기
			//LinuxTreeViewItem.BackgroundReConnector.DoWork += LinuxTreeViewItem.BackgroundReConnect;
			//LinuxTreeViewItem.BackgroundReConnector.RunWorkerCompleted += LinuxTreeViewItem.BackgroundReConnectCallBack;
			//LinuxTreeViewItem.BackgroundReConnector.WorkerReportsProgress = true;
			//LinuxTreeViewItem.BackgroundReConnector.WorkerSupportsCancellation = true;
			//LinuxTreeViewItem.BackgroundReConnector.RunWorkerAsync();
			//LinuxTreeViewItem.BackgroundReConnector.ProgressChanged += new ProgressChangedEventHandler(_backgroundWorker_ProgressChanged);
		}

		private string selected_config_file_path = "Not Selected";
		public string Selected_config_file_path
		{
			get { return selected_config_file_path; }
			set
			{
				selected_config_file_path = value;
				string[] splited = selected_config_file_path.Split('\\');
				textBlock_selected_config_file_name.Text = splited[splited.Length - 1];
			}
		}
		private void OnClickButtonSelectConfigFile(object sender, EventArgs e)
		{
			if(JsonInfo.current == null)
				return;

			JsonInfo.current.Clear();
			OpenFileDialog ofd = new OpenFileDialog();

			// 초기경로 지정
			ofd.InitialDirectory = root_path;

			if(JsonInfo.current.Path != null)
			{
				string dir_path = JsonInfo.current.Path.Substring(0, JsonInfo.current.Path.LastIndexOf('\\') + 1);
				DirectoryInfo d = new DirectoryInfo(dir_path);
				if(d.Exists)
					ofd.InitialDirectory = dir_path;
			}

			// 파일 열기
			ofd.Filter = "JSon Files (.json)|*.json";
			if(ofd.ShowDialog(/*this*/) == true)
			{
				Selected_config_file_path = ofd.FileName;
				Console.WriteLine(Selected_config_file_path);
				//Console.WriteLine(ofd.FileName);

				//string json = FileContoller.read(ofd.FileName);
				//refreshJsonTree(JsonController.parseJson(json));

				//JsonInfo.current.Path = ofd.FileName;
			}
		}
		#endregion
	}
}