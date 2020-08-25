using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCSharpApp
{
    public partial class Form1 : Form
    {
        DataTable table;

        public Form1()
        {
            InitializeComponent();
        }


        
        //프로그램 시작할 시 호출되는 함수
        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable(); //객체 만들기
            table.Columns.Add("Title", typeof(String));
            table.Columns.Add("Messages", typeof(String));

            dataGridView.DataSource = table; //미리 윈폼에 만들어둔 DataGridView와 연결하기
            dataGridView.Columns["Messages"].Visible = false;
            dataGridView.Columns["Title"].Width = dataGridView.Size.Width;
        }

        //버튼 클릭 시 텍스트 박스 초기화
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtMessage.Clear();
        }

        //버튼 클릭 시 DataGridView에 해당 항목 추가
        private void btnSave_Click(object sender, EventArgs e)
        {
            table.Rows.Add(txtTitle.Text, txtMessage.Text);
        }

        //버튼 클릭시 DataGridView에서 클릭 되어져있는 행 읽기
        private void btnRead_Click(object sender, EventArgs e)
        {
            int index = dataGridView.CurrentCell.RowIndex;

            if(index > -1)
            {
                txtTitle.Text = table.Rows[index].ItemArray[0].ToString();
                txtMessage.Text = table.Rows[index].ItemArray[1].ToString();
            }
        }

        //버튼 클릭시 DataGridView에서 클릭 되어져있는 행 삭제
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = dataGridView.CurrentCell.RowIndex;
            table.Rows[index].Delete();
        }
    }
}
