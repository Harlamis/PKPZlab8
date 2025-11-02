using System.Windows;

namespace Task3
{
    public enum ChineseZodiac
    {
        Monkey = 1,
        Rooster = 2,
        Dog = 3,
        Pig = 4,
        Rat = 5,
        Ox = 6,
        Tiger = 7,
        Rabbit = 8,
        Dragon = 9,
        Snake = 10,
        Horse = 11,
        Goat = 12
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string userInput = InputTextBox.Text.Trim();

            while (userInput != "0")
            {
                try
                {
                    int cycleNumber = int.Parse(userInput);
                    string result = GetZodiacInfo(cycleNumber);
                    ResultTextBlock.Text = result;
                }
                catch
                {
                    ResultTextBlock.Text = "Будь ласка, введіть коректне число (1-12) або 0.";
                }

                return;
            }

            if (userInput == "0")
            {
                Application.Current.Shutdown();
            }
        }

        private string GetZodiacInfo(int cycleNumber)
        {
            ChineseZodiac sign = (ChineseZodiac)cycleNumber;
            string characteristic;

            switch (sign)
            {
                case ChineseZodiac.Monkey:
                    characteristic = "1 – Мавпа (хитрість)";
                    break;
                case ChineseZodiac.Rooster:
                    characteristic = "2 – Півень (фанфараон)";
                    break;
                case ChineseZodiac.Dog:
                    characteristic = "3 – Собака (справедливість)";
                    break;
                case ChineseZodiac.Pig:
                    characteristic = "4 – Свиня (добра старина)";
                    break;
                case ChineseZodiac.Rat:
                    characteristic = "5 – Щур (агресивність)";
                    break;
                case ChineseZodiac.Ox:
                    characteristic = "6 – Бик (робота, сім’я)";
                    break;
                case ChineseZodiac.Tiger:
                    characteristic = "7 – Тигр (енергія)";
                    break;
                case ChineseZodiac.Rabbit:
                    characteristic = "8 – Кролик (спокійність)";
                    break;
                case ChineseZodiac.Dragon:
                    characteristic = "9 – Дракон («не все золото, що блищить»)";
                    break;
                case ChineseZodiac.Snake:
                    characteristic = "10 – Змія (мудрість)";
                    break;
                case ChineseZodiac.Horse:
                    characteristic = "11 – Кінь (чесність)";
                    break;
                case ChineseZodiac.Goat:
                    characteristic = "12 – Коза (примхливість)";
                    break;
                default:
                    characteristic = "Номер циклу не знайдено. Введіть число від 1 до 12.";
                    break;
            }
            return characteristic;
        }
    }
}
