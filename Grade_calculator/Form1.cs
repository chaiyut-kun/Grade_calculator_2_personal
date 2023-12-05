using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grade_calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //unknown
        private void label1_Click(object sender, EventArgs e)
        {
            //unknown
        }

        // asset

        int arr_index = 0;

        string[] all_id = new string[1000];
        string[] all_name = new string[1000];
        int[] all_score = new int[1000];

        string id_student ;
        string name_student ;
        string score_student;

        int[] cp_score = new int[1];
        int start = 0, stop, sub_arr_length;
        int max_idx , max_value , min_value , min_idx;

        // arr สำหรับเก็บการคำนวณ นศ.ที่ได้ A จำนวน n * 4 + ได้ B+ จำนวน n * 3.5 ..... ไปเรื่อยๆ
        float[] all_grade = new float[8];

        // เก็บจำนวนที่ไดเกรด A  , B  , C , D ว่าได้กี่ครั้งๆ
        int[] n_of_grade = new int[8];

        //asset

       

        public void Save_button_Click(object sender, EventArgs e)
        {

            Get_value();

            Min_Max();
                        
            //average output 
            //double average_grade = (double)(all_score.Sum() / arr_index);
            text_avg_point.Text = $"{(double)all_score.Sum() / (double)arr_index:0.00}";


            // ส่วน เช็คค่าและแสดงผล
            
            calcualte();
        }

         public void calcualte()
        {

            int point = all_score[arr_index - 1];
            if (point >= 80 && point <= 100)
            {
                // n of A 
                n_of_grade[0] += 1;
                text_A_box.Text = n_of_grade[0].ToString();
                all_grade[0] = n_of_grade[0] * 4;

            }
            else if (point >= 75 && point <= 79)
            {
                // n of B+
                n_of_grade[1] += 1;
                text_B_plus_box.Text = n_of_grade[1].ToString();
                all_grade[1] = n_of_grade[1] * 3.5f;
            }
            else if (point >= 70 && point <= 74)
            {
                // n of B
                n_of_grade[2] += 1;
                text_B_box.Text = n_of_grade[2].ToString();
                all_grade[2] = n_of_grade[2] * 3.0f;

            }
            else if (point >= 65 && point <= 69)
            {
                // C+
                n_of_grade[3] += 1;
                text_C_plus_box.Text = n_of_grade[3].ToString();
                all_grade[3] = n_of_grade[3] * 2.5f;
            }
            else if (point >= 60 && point <= 64)
            {
                // C
                n_of_grade[4] += 1;
                text_C_box.Text = n_of_grade[4].ToString();
                all_grade[4] = n_of_grade[4] * 2.0f;
            }
            else if (point >= 55 && point <= 59)
            {
                // D+
                n_of_grade[5] += 1;
                text_D_plus_box.Text = n_of_grade[5].ToString();
                all_grade[5] = n_of_grade[5] * 1.5f;
            }
            else if (point >= 50 && point <= 54)
            {
                //D
                n_of_grade[6] += 1;
                text_D_box.Text = n_of_grade[6].ToString();
                all_grade[6] = n_of_grade[6] * 1.0f;
            }
            else
            {
                //F
                n_of_grade[7] += 1;
                text_F_box.Text = n_of_grade[7].ToString();
            }

            text_avg_box.Text = $"{(double)all_grade.Sum() / (double)arr_index:0.00}";

        }

        // ฟังก์ชันคำนวนเกรด A B C ... และ ค่าเฉลี่ยของนักเรียนทุกคน
      
        public void Get_value()
        {

            id_student = text_id_student.Text;
            name_student = text_name.Text;
            score_student = (text_point.Text);

            all_id[arr_index] = id_student;
            all_name[arr_index] = name_student;
            all_score[arr_index] = int.Parse(score_student);

            arr_index++;
            text_name.Text = "";
            text_id_student.Text = "";
            text_point.Text = "";

        }

        public void Min_Max()
{
    // max value , index
    max_value = all_score.Max();
    max_idx = all_score.ToList().IndexOf(max_value);

    // show output max
    text_id_student_max.Text = $"{all_id[max_idx]}";
    text_name_max.Text = $"{all_name[max_idx]}";
    text_point_max.Text = $"{all_score[max_idx]}";

    // find min value by cp_arr and length = จำนวนที่เราได้ใส่ค่าเข้ามา ตัวนับคือ arr_index
    cp_score = new int[arr_index];
    stop = arr_index;
    sub_arr_length = stop;
    Array.Copy(all_score, start, cp_score, 0, sub_arr_length);
    min_value = cp_score.Min();
    

    min_idx = all_score.ToList().IndexOf(min_value);

    //show output min
    text_id_student_min.Text = $"{all_id[min_idx]}";
    text_name_min.Text = $"{all_name[min_idx]}";
    text_point_min.Text = $"{all_score[min_idx]}";
}
        //Min result

        
        

        private void text_id_student_min_TextChanged(object sender, EventArgs e)
        {

        }

        private void text_name_min_TextChanged(object sender, EventArgs e)
        {

        }

        private void text_point_min_TextChanged(object sender, EventArgs e)
        {

        }

        private void text_avg_point_TextChanged(object sender, EventArgs e)
        {

        }

        private void text_id_student_TextChanged(object sender, EventArgs e)
        {

        }

        private void group_result_box_Enter(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            // A box
        }

        //Min result


        //Max Result
        private void text_id_student_max_TextChanged(object sender, EventArgs e)
        {

            text_id_student_max.Text = $"{all_id[max_idx]}";

        }

        private void text_name_max_TextChanged(object sender, EventArgs e)
        {

            text_name_max.Text = $"{all_name[max_idx]}";

        }

        private void text_point_max_TextChanged(object sender, EventArgs e)
        {

            //text_point_max.Text = $"{all_[max_idx]}";

        }
        //Max result

    }
}
