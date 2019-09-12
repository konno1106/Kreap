using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_Kreap
{
    public partial class Form1 : Form
    {

        int r1, r2;                           //2～8のランダムな値を代入する為の値
        bool sttflg = false;                  //スタートボタンが押されたか判定する値
        int ans = 0;                         //正答数を代入する為の値
        int val = 0;                         //同じ数字が3以上(例:2 3 4 2)離す為に使う判定の変数
        int que = 0;                         //ボタンが押された回数(回答数)を代入する為の値
        int time = 60;                       //タイマーの初期値(60秒)
        int line = 1;                        //回数(60秒で1回)を代入する為の値
        int[] array = new int[15];
        Random rnd1 = new System.Random();   //Randomクラスのインスタンスを生成

        public Form1()
        {
            InitializeComponent();
            queLab.Text = que.ToString();          //queLabに現在の回数(回答数)を表示する
            timeLab.Text = time.ToString();         //timeLabに現在のタイマーを表示する
            lineLab.Text = line.ToString();         //lineLabに現在の回数(行)を表示する
            ansLab.Text = ans.ToString();

        }

        /// <summary>
        /// 数値ボタン(0～9)のクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Click(object sender, EventArgs e)
        {
            var button = sender as Button;          //押されたボタンの情報を取得する
            string atai = button.Text;
            if (sttflg == true)                   //スタートボタンが押されているか判定
            {
                que += 1;                          //ボタンが押された回数(回答数)をカウント
                queLab.Text = "";                  //回答数を表示するqueLabを初期化する
                queLab.Text += que.ToString();     //queLabに現在の回数(回答数)を表示する
                processing(atai);
            }
        }

        /// <summary>
        /// スタートボタンのクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button11_Click(object sender, EventArgs e)
        {
            queLab.Text = que.ToString();          //queLabに現在の回数(回答数)を表示する
            timeLab.Text = time.ToString();         //timeLabに現在のタイマーを表示する
            lineLab.Text = line.ToString();         //lineLabに現在の回数(行)を表示する
            timer1.Start();                         //タイマーを起動

            if (sttflg == false)                     //1回目の処理
            {
                r1 = rnd1.Next(7) + 2;              //2～8のランダムな値をr1に代入
                r2 = rnd1.Next(7) + 2;              //2～8のランダムな値をr2に代入
                txtBox1.Text = r1.ToString();       //r1の結果をtxtBox1に表示


                while (r1 == r2)                    //r1とr2の値が同じ場合ループする
                {
                    r2 = rnd1.Next(7) + 2;      　　//r2に新しい値を代入
                }

                txtBox2.Text = r2.ToString();       //r1の結果をtxtBox2に表示
                sttflg = true;                      //スタートが押された場合trueにする
            }
        }

        /// <summary>
        /// タイマー処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object sender, EventArgs e)
        {

            time--;                                 //タイマーをデクリメント
            if (time == -1)
            {
                time = 60;                          //タイマーをリセット
                if (line <= 15)
                {
                    array[line - 1] = ans;          //ラインが15になったら回答数を配列に代入
                }
                line += 1;
                if(line > 15)
                { 
                    reset();
                }
                ans = 0;
                que = 0;                        //回答数を初期化
                queLab.Text = que.ToString();   //queLabに現在の回数(回答数)を表示する

            }
            timeLab.Text = time.ToString();         //timeLabに現在のタイマーを表示する
            lineLab.Text = line.ToString();         //lineLabに現在の回数(行)を表示する
            ansLab.Text = ans.ToString();
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(array);
            frm.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        private void processing(String atai)
        {
            int kai = (r1 + r2) % 10;
            if (kai.ToString() == atai)
            {
                ans++;
                ansLab.Text = ans.ToString();
            }

            val = r1;                       //valにr1の値を保持 
            r1 = r2;                        //r1にr2の値を代入
            txtBox1.Text = r1.ToString();   //r1(左側)の値を表示
            r2 = rnd1.Next(7) + 2;              
            while (r1 == r2 || r2 == val)
            {
                r2 = rnd1.Next(7);
                r2 += 2;
            }

            txtBox2.Text = r2.ToString();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void reset()
        {
            timer1.Stop();                   //タイマーを止める
            sttflg = false;                   //スタートボタンが押されたか判定する値
            val = 0;                         //同じ数字が3以上(例:2 3 4 2)離す為に使う判定の変数
            que = 0;                         //ボタンが押された回数(回答数)を代入する為の値
            time = 60;                       //タイマーの初期値(60秒)
            line = 1;                        //回数(60秒で1回)を代入する為の値
            ans = 0;
            
            txtBox1.Text = "";
            txtBox2.Text = "";
            queLab.Text = que.ToString();          //queLabに現在の回数(回答数)を表示する
            timeLab.Text = time.ToString();         //timeLabに現在のタイマーを表示する
            lineLab.Text = line.ToString();         //lineLabに現在の回数(行)を表示する
            ansLab.Text = ans.ToString();
        }
    }
}
