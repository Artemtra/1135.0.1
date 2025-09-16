namespace _1135._0._1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private double currentNumber = 0;
        private double previousNumber = 0;
        private string currentOperation = "";
        private bool isNewOperation = true;
        private string calculationHistory = "";
        public MainPage()
        {
            InitializeComponent();
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            displayLabel.Text = currentNumber.ToString();
            historyLabel.Text = calculationHistory;
        }

        private void OnDigitClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            string digit = button.Text;

            if (isNewOperation)
            {
                currentNumber = 0;
                isNewOperation = false;
            }

            if (currentNumber == 0 && !displayLabel.Text.Contains(","))
            {
                currentNumber = double.Parse(digit);
            }
            else
            {
                string currentText = currentNumber.ToString();
                currentText += digit;
                currentNumber = double.Parse(currentText);
            }

            UpdateDisplay();
        }

        private void OnDecimalClicked(object sender, EventArgs e)
        {
            if (isNewOperation)
            {
                currentNumber = 0;
                isNewOperation = false;
            }
            if (!displayLabel.Text.Contains(","))
            {
                displayLabel.Text += ",";
            }

        }

        private void OnOperatorClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            string operation = button.Text;

            if (!isNewOperation)
            {
                Calculate();
            }

            previousNumber = currentNumber;
            currentOperation = operation;
            calculationHistory = $"{previousNumber} {currentOperation}";
            isNewOperation = true;
            UpdateDisplay();
        }

        private void OnEqualsClicked(object sender, EventArgs e)
        {
            Calculate();
            calculationHistory = "";
            isNewOperation = true;
            UpdateDisplay();
        }

        private void Calculate()
        {
            if (!string.IsNullOrEmpty(currentOperation))
            {
                calculationHistory += $" {currentNumber} =";

                switch (currentOperation)
                {
                    case "+":
                        currentNumber = previousNumber + currentNumber;
                        break;
                    case "-":
                        currentNumber = previousNumber - currentNumber;
                        break;
                    case "X":
                        currentNumber = previousNumber * currentNumber;
                        break;
                    case "/":
                        if (currentNumber != 0)
                            currentNumber = previousNumber / currentNumber;
                        else
                            DisplayAlert("Ошибка", "Деление на ноль невозможно", "OK");
                        break;
                }

                currentOperation = "";
                previousNumber = 0;
            }
        }
        private void OnClearAllMemory(object sender, EventArgs e)
        {
            calculationHistory += "";
        }
        private void OnMemoryRecall(object sender, EventArgs e)
        {
            calculationHistory = "";
        }
        private void OnMemoryAdd(object sender, EventArgs e)
        {
            calculationHistory = "";
        }
        private void OnMemorySubact(object sender, EventArgs e)
        {
            calculationHistory = "";
        }
        private void OnMemoryStore(object sender, EventArgs e)
        {
            calculationHistory = "";
        }



        private void OnClearClicked(object sender, EventArgs e)
        {
            currentNumber = 0;
            previousNumber = 0;
            currentOperation = "";
            calculationHistory = "";
            isNewOperation = true;
            UpdateDisplay();
        }

        private void OnClearEntryClicked(object sender, EventArgs e)
        {
            currentNumber = 0;
            UpdateDisplay();
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            string currentText = currentNumber.ToString();
            if (currentText.Length > 1)
            {
                currentText = currentText.Substring(0, currentText.Length - 1);
                currentNumber = double.Parse(currentText);
            }
            else
            {
                currentNumber = 0;
            }
            UpdateDisplay();
        }

        private void OnSignClicked(object sender, EventArgs e)
        {
            currentNumber *= -1;
            UpdateDisplay();
        }

        private void OnPercentageClicked(object sender, EventArgs e)
        {
            if (historyLabel.Text != null)
            {
            displayLabel.Text = (currentNumber / 100).ToString();
            }

            

        }

        private void OnSquareRootClicked(object sender, EventArgs e)
        {
            if (currentNumber >= 0)
            {
                currentNumber = Math.Sqrt(currentNumber);
                calculationHistory = $"√({currentNumber})";
                UpdateDisplay();
            }
            else
            {
                DisplayAlert("Ошибка", "Нельзя извлечь корень из отрицательного числа", "OK");
            }
        }

        private void OnSquareClicked(object sender, EventArgs e)
        {
            currentNumber = Math.Pow(currentNumber, 2);
            calculationHistory = $"({currentNumber})²";
            UpdateDisplay();
        }

        private void OnReciprocalClicked(object sender, EventArgs e)
        {
            if (currentNumber != 0)
            {
                currentNumber = 1 / currentNumber;
                calculationHistory = $"1/({currentNumber})";
                UpdateDisplay();
            }
            else
            {
                DisplayAlert("Ошибка", "Деление на ноль невозможно", "OK");
            }
        }


    }
}
