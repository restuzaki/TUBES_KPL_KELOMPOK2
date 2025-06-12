using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUBES_KPL_KELOMPOK2.Services;

namespace GUI_KPL
{
    public partial class Chatbot : Form
    {
        private readonly ChatbotView _chatbotService;
        private readonly Apotekku_API.Models.User _currentUser;
        private FlowLayoutPanel chatContainer;
        private bool isFirstMessage = true;

        public Chatbot(Apotekku_API.Models.User currentUser) 
        {
            InitializeComponent();
            _chatbotService = new ChatbotView();
            _currentUser = currentUser; 

            chatContainer = new FlowLayoutPanel
            {
                AutoScroll = true,
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };

            panel2.Controls.Add(chatContainer);
            panel2.Controls.SetChildIndex(chatContainer, 2);


            button1.Click += async (s, e) => await SendMessageAsync();

            
            textBox1.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    if (!string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        await SendMessageAsync();
                    }
                }
            };

            button2.Click += (s, e) => this.Close();
        }

        private async Task SendMessageAsync()
        {
            string userMessage = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(userMessage)) return;

            AddUserMessage(userMessage);
            textBox1.Clear();

            try
            {
                string botResponse = await _chatbotService.GetChatbotResponse(userMessage);
                AddBotMessage(botResponse);
            }
            catch (Exception ex)
            {
                AddBotMessage("Terjadi kesalahan: " + ex.Message);
            }

            ScrollToBottom();
        }

        private void AddUserMessage(string message)
        {
            AddMessagePanel(message, isUser: true);
        }

        private void AddBotMessage(string message)
        {
            AddMessagePanel(message, isUser: false);
        }

        private void AddMessagePanel(string message, bool isUser)
        {
            
            if (isFirstMessage)
            {
                Panel separator1 = new()
                {
                    Height = 100,
                    Width = chatContainer.Width - 20,
                    BackColor = Color.White,
                    Margin = new Padding(0)
                };
                chatContainer.Controls.Add(separator1);

                
                isFirstMessage = false;
            }

            Panel panel = new()
            {
                AutoSize = true,
                MaximumSize = new Size(chatContainer.Width - 40, 0),
                BackColor = isUser ? Color.YellowGreen : Color.LightGray,
                Padding = new Padding(10),
                Margin = new Padding(5, 0, 5, 0)
            };

            Label label = new()
            {
                Text = message,
                AutoSize = true,
                MaximumSize = new Size(chatContainer.Width - 60, 0),
                Padding = new Padding(5),
                Font = new Font("Yu Gothic Medium", 9F),
                ForeColor = isUser ? Color.White : Color.Black
            };

            panel.Controls.Add(label);

            Panel separator = new()
            {
                Height = 10,
                Width = chatContainer.Width - 20,
                BackColor = Color.White,
                Margin = new Padding(0)
            };

            chatContainer.Controls.Add(separator);
            chatContainer.Controls.Add(panel);
        }


        private void ScrollToBottom()
        {
            chatContainer.VerticalScroll.Value = chatContainer.VerticalScroll.Maximum;
            chatContainer.PerformLayout();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuUser menuUser = new MenuUser(_currentUser);
            menuUser.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
