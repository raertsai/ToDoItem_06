using System;
using System.Collections.Generic;
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

namespace accounting
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            string[] lines = { };
            // 如果已有檔案,讀取他
            try
            {
                lines = System.IO.File.ReadAllLines(@"D:\accountingApp\data.txt");
            }
            // 如果沒有檔案,新增一個
            catch
            {
                List<string> standard = new List<string>();
            }

            // 解析每一行
            foreach (string line in lines)
            {
                // 用 | 隔開不同資料
                string[] parts = line.Split('|');

                // 建立 category
                category categorys = new category();

                // 讀取category的資料
                categorys.categoryDate.Text = parts[0];
                categorys.categoryName.Text = parts[1];
                categorys.categoryPrice.Text = parts[2];

                // 放到清單列表中
                categoryList.Children.Add(categorys);
            }
        }
        // 按下+鍵時
        private void addBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 產生項目
            category categorys = new category();

            //放到清單中
            categoryList.Children.Add(categorys);
        }

        // 關閉程式時
        private void windowClosed(object sender, EventArgs e)
        {
            List<string> Texts = new List<string>();

            foreach (category categorys in categoryList.Children)
            {

                string data = "";

                // 每一種資料以"|"分隔加入Texts字串
                data += categorys.categoryDate.Text + "|" + categorys.categoryName.Text + "|" + categorys.categoryPrice.Text;

                // 存入Texts的陣列
                Texts.Add(data);
            }
         
        }
    }



}