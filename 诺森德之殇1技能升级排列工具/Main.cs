using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 诺森德之殇1技能升级排列工具
{
    public partial class Main : Form
    {
        List<TextBox> FirstSkill, SecondSkill, ThirdSkill, FourthSkill, FifthSkill, AllTextBox;
        private void CopySkill(TextBox tb)
        {
            if (tb.Text != "")
            {
                Clipboard.SetText(tb.Text);
            }
            else
            {
                MessageBox.Show("技能加点为空");
            }
        }
        private void GetSkill(List<TextBox> tb,TextBox t)
        {
            StringBuilder s = new StringBuilder('^');
            foreach (var item in tb)
            {
                if (item.Text == "")
                {
                    MessageBox.Show("你还没有将加点填写完整");
                    return;
                }
                else
                {
                s.Append(item.Text + '^') ;

                }
            }
            t.Text = s.ToString();
        }
        private void ClearSkill(List<TextBox> tb)
        {
            foreach (var item in tb)
            {
                item.Clear();
            }
        }
        private void FirstCopy_Click(object sender, EventArgs e)
        {
            CopySkill(FirstRusult);
        }

        private void SecondCopy_Click(object sender, EventArgs e)
        {
            CopySkill(SecondRusult);
        }

        private void ThirdCopy_Click(object sender, EventArgs e)
        {
            CopySkill(ThirdRusult);
        }

        private void FourthCopy_Click(object sender, EventArgs e)
        {
            CopySkill(FourthRusult);
        }

        private void FifthCopy_Click(object sender, EventArgs e)
        {
            CopySkill(FifthRusult);
        }

        private void FirstString_Click(object sender, EventArgs e)
        {
            GetSkill(FirstSkill, FirstRusult);
        }

        private void SecondString_Click(object sender, EventArgs e)
        {
            GetSkill(SecondSkill, SecondRusult);
        }

        private void ThirdString_Click(object sender, EventArgs e)
        {
            GetSkill(ThirdSkill, ThirdRusult);
        }

        private void FourthString_Click(object sender, EventArgs e)
        {
            GetSkill(FourthSkill, FourthRusult);
        }

        private void FifthString_Click(object sender, EventArgs e)
        {
            GetSkill(FifthSkill, FifthRusult);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearSkill(FirstSkill);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearSkill(SecondSkill);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearSkill(ThirdSkill);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearSkill(FourthSkill);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClearSkill(FifthSkill); 
        }

        List<int> AllLevel = new List<int> { };
        public Main()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            版本说明 a = new 版本说明();
            a.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 61; i++)
            {
                AllLevel.Add(0);
            }
            FirstSkill = new List<TextBox> { First_1, First_2, First_3, First_4, First_5, First_6, First_7, First_8, First_9 };
            SecondSkill = new List<TextBox> { Second_1, Second_2, Second_3, Second_4, Second_5, Second_6, Second_7, Second_8, Second_9 };
            ThirdSkill = new List<TextBox> { Third_1, Third_2, Third_3, Third_4, Third_5, Third_6, Third_7, Third_8, Third_9 };
            FourthSkill = new List<TextBox> { Fourth_1, Fourth_2, Fourth_3 };
            FifthSkill = new List<TextBox> { Fifth_1, Fifth_2, Fifth_3, Fifth_4, Fifth_5, Fifth_6, Fifth_7, Fifth_8, Fifth_9, Fifth10, Fifth11, Fifth12, Fifth13, Fifth14, Fifth15, Fifth16, Fifth17, Fifth18, Fifth19, Fifth20, Fifth21, Fifth22, Fifth23, Fifth24, Fifth25, Fifth26, Fifth27, Fifth28, Fifth29, Fifth30 };
            AllTextBox = new List<TextBox> { };
            AllTextBox.AddRange(FirstSkill);
            AllTextBox.AddRange(SecondSkill);
            AllTextBox.AddRange(ThirdSkill);
            AllTextBox.AddRange(FourthSkill);
            AllTextBox.AddRange(FifthSkill);
            foreach (var item in AllTextBox)
            {
                item.Leave += new EventHandler((object obj, EventArgs ea) => OnlyNumber((TextBox)obj));
            }
        }
        public void OnlyNumber(TextBox tb)
        {
            string str = tb.Text;
            if (str != "")
            {
                if (Regex.IsMatch(str, @"^\d+$"))
                {
                    int intstr = int.Parse(str);
                    if (intstr > 60 || intstr == 0)
                    {
                        tb.Clear();
                        return;
                    }
                    foreach (var item in AllTextBox)
                    {
                        if (item.Text == str && item != tb)
                        {
                            //tb.Clear();
                            for (int i = 1; i < 61; i++)
                            {
                                if (!AllLevel.Contains(i))
                                {
                                    tb.Text = i.ToString();
                                    break;
                                }
                            }
                            MessageBox.Show("你输入的等级已经存在,已为你自动输入一个未使用的等级");
                            break;
                        }
                    }
                    AllLevel[tb.TabIndex - 1] = int.Parse(tb.Text);
                }
                else
                {
                    tb.Clear();
                }
            }
            else
            {
                AllLevel[tb.TabIndex - 1] = 0;
            }
        }
    }
}
