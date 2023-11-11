using Project_BlueLock.Data.DB;
using Project_BlueLock.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace Project_BlueLock.ViewModels
{
    class PlayerProfileVM : BaseVM, IPageViewModel
    {
        public ICommand NextCommand { get; private set; }

        public event EventHandler<EventArgs<string>>? ViewChanged;
        public string PageId { get; set; }
        public string Title { get; set; } = "View 3";

        public PlayerProfileVM(string pageIndex = "3")
        {
            PageId = pageIndex;
            NextCommand = new RelayCommand(CreatePlayerProfile);
        }

        private int _userID;
        public int UserID
        {
            get { return _userID; }
            set
            {
                _userID = value;
                OnPropertyChanged(nameof(UserID));
            }
        }

        private string _height;
        public string Height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
                TbHeightErrorVisibility = Visibility.Collapsed;
                TbHeightErrorText = "";
            }
        }

        private string _weight;
        public string Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
                TbHeightErrorVisibility = Visibility.Collapsed;
                TbHeightErrorText = "";
            }
        }

        private string _country;
        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                OnPropertyChanged(nameof(Country));
                //TbCountryErrorVisibility = Visibility.Collapsed;
                //TbCountryErrorText = "";
            }
        }

        private string _birthday;
        public string Birthday
        {
            get { return _birthday; }
            set
            {
                _birthday = value;
                OnPropertyChanged(nameof(Birthday));
                TbBirthdayErrorVisibility = Visibility.Collapsed;
                TbBirthdayErrorText = "";
            }
        }

        private string _gender;
        public string Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        private string _shooting;
        public string Shooting
        {
            get { return _shooting; }
            set
            {
                // Validate if input contains only numbers
                if (System.Text.RegularExpressions.Regex.IsMatch(value, @"^\d+$"))
                {
                    _shooting = value;
                    OnPropertyChanged(nameof(Shooting));
                    TbShootingErrorVisibility = Visibility.Collapsed;
                    TbShootingErrorText = "";
                }
                else
                {
                    TbShootingErrorVisibility = Visibility.Visible;
                    TbShootingErrorText = "Weight must be a number.";
                }
            }
        }

        private string _dribbling;
        public string Dribbling
        {
            get { return _dribbling; }
            set
            {
                // Validate if input contains only numbers
                if (System.Text.RegularExpressions.Regex.IsMatch(value, @"^\d+$"))
                {
                    _dribbling = value;
                    OnPropertyChanged(nameof(Dribbling));
                    TbDribblingErrorVisibility = Visibility.Collapsed;
                    TbDribblingErrorText = "";
                }
                else
                {
                    TbDribblingErrorVisibility = Visibility.Visible;
                    TbDribblingErrorText = "Weight must be a number.";
                }
            }
        }

        private string _passing;
        public string Passing
        {
            get { return _passing; }
            set
            {
                // Validate if input contains only numbers
                if (System.Text.RegularExpressions.Regex.IsMatch(value, @"^\d+$"))
                {
                    _passing = value;
                    OnPropertyChanged(nameof(Passing));
                    TbPassingErrorVisibility = Visibility.Collapsed;
                    TbPassingErrorText = "";
                }
                else
                {
                    TbPassingErrorVisibility = Visibility.Visible;
                    TbPassingErrorText = "Weight must be a number.";
                }
            }
        }

        private string _physical;
        public string Physical
        {
            get { return _physical; }
            set
            {
                // Validate if input contains only numbers
                if (System.Text.RegularExpressions.Regex.IsMatch(value, @"^\d+$"))
                {
                    _physical = value;
                    OnPropertyChanged(nameof(Physical));
                    TbPhysicalErrorVisibility = Visibility.Collapsed;
                    TbPhysicalErrorText = "";
                }
                else
                {
                    TbPhysicalErrorVisibility = Visibility.Visible;
                    TbPhysicalErrorText = "Weight must be a number.";
                }
            }
        }

        private string _touch;
        public string Touch
        {
            get { return _touch; }
            set
            {
                // Validate if input contains only numbers
                if (System.Text.RegularExpressions.Regex.IsMatch(value, @"^\d+$"))
                {
                    _touch = value;
                    OnPropertyChanged(nameof(Touch));
                    TbTouchErrorVisibility = Visibility.Collapsed;
                    TbTouchErrorText = "";
                }
                else
                {
                    TbTouchErrorVisibility = Visibility.Visible;
                    TbTouchErrorText = "Weight must be a number.";
                }
            }
        }

        private string _pace;
        public string Pace
        {
            get { return _pace; }
            set
            {
                // Validate if input contains only numbers
                if (System.Text.RegularExpressions.Regex.IsMatch(value, @"^\d+$"))
                {
                    _pace = value;
                    OnPropertyChanged(nameof(Pace));
                    TbPaceErrorVisibility = Visibility.Collapsed;
                    TbPaceErrorText = "";
                }
                else
                {
                    TbPaceErrorVisibility = Visibility.Visible;
                    TbPaceErrorText = "Weight must be a number.";
                }
            }
        }

        private Visibility tbHeightErrorVisibility = Visibility.Collapsed;
        public Visibility TbHeightErrorVisibility
        {
            get { return tbHeightErrorVisibility; }
            set
            {
                tbHeightErrorVisibility = value;
                OnPropertyChanged(nameof(TbHeightErrorVisibility));
            }
        }

        private string tbHeightErrorText;
        public string TbHeightErrorText
        {
            get { return tbHeightErrorText; }
            set
            {
                tbHeightErrorText = value;
                OnPropertyChanged(nameof(TbHeightErrorText));
            }
        }

        private Visibility tbWeightVisibility = Visibility.Collapsed;
        public Visibility TbWeightErrorVisibility
        {
            get { return tbWeightVisibility; }
            set
            {
                tbWeightVisibility = value;
                OnPropertyChanged(nameof(TbWeightErrorVisibility));
            }
        }

        private string tbWeightErrorText;
        public string TbWeightErrorText
        {
            get { return tbWeightErrorText; }
            set
            {
                tbWeightErrorText = value;
                OnPropertyChanged(nameof(TbWeightErrorText));
            }
        }

        private Visibility tbNationalityVisibility = Visibility.Collapsed;
        public Visibility TbNationalityErrorVisibility
        {
            get { return tbNationalityVisibility; }
            set
            {
                tbNationalityVisibility = value;
                OnPropertyChanged(nameof(TbNationalityErrorVisibility));
            }
        }

        private string tbNationalityErrorText;
        public string TbNationalityErrorText
        {
            get { return tbNationalityErrorText; }
            set
            {
                tbNationalityErrorText = value;
                OnPropertyChanged(nameof(TbNationalityErrorText));
            }
        }

        private Visibility tbBirthdayVisibility = Visibility.Collapsed;
        public Visibility TbBirthdayErrorVisibility
        {
            get { return tbBirthdayVisibility; }
            set
            {
                tbBirthdayVisibility = value;
                OnPropertyChanged(nameof(TbBirthdayErrorVisibility));
            }
        }

        private string tbBirthdayErrorText;
        public string TbBirthdayErrorText
        {
            get { return tbBirthdayErrorText; }
            set
            {
                tbBirthdayErrorText = value;
                OnPropertyChanged(nameof(TbBirthdayErrorText));
            }
        }

        private Visibility tbShootingVisibility = Visibility.Collapsed;
        public Visibility TbShootingErrorVisibility
        {
            get { return tbShootingVisibility; }
            set
            {
                tbShootingVisibility = value;
                OnPropertyChanged(nameof(TbShootingErrorVisibility));
            }
        }

        private string tbShootingErrorText;
        public string TbShootingErrorText
        {
            get { return tbShootingErrorText; }
            set
            {
                tbShootingErrorText = value;
                OnPropertyChanged(nameof(TbShootingErrorText));
            }
        }

        private Visibility tbDribblingVisibility = Visibility.Collapsed;
        public Visibility TbDribblingErrorVisibility
        {
            get { return tbDribblingVisibility; }
            set
            {
                tbDribblingVisibility = value;
                OnPropertyChanged(nameof(TbDribblingErrorVisibility));
            }
        }

        private string tbDribblingErrorText;
        public string TbDribblingErrorText
        {
            get { return tbDribblingErrorText; }
            set
            {
                tbDribblingErrorText = value;
                OnPropertyChanged(nameof(TbDribblingErrorText));
            }
        }

        private Visibility tbPassingVisibility = Visibility.Collapsed;
        public Visibility TbPassingErrorVisibility
        {
            get { return tbPassingVisibility; }
            set
            {
                tbPassingVisibility = value;
                OnPropertyChanged(nameof(TbPassingErrorVisibility));
            }
        }

        private string tbPassingErrorText;
        public string TbPassingErrorText
        {
            get { return tbPassingErrorText; }
            set
            {
                tbPassingErrorText = value;
                OnPropertyChanged(nameof(TbPassingErrorText));
            }
        }

        private Visibility tbPhysicalVisibility = Visibility.Collapsed;
        public Visibility TbPhysicalErrorVisibility
        {
            get { return tbPhysicalVisibility; }
            set
            {
                tbPhysicalVisibility = value;
                OnPropertyChanged(nameof(TbPhysicalErrorVisibility));
            }
        }

        private string tbPhysicalErrorText;
        public string TbPhysicalErrorText
        {
            get { return tbPhysicalErrorText; }
            set
            {
                tbPhysicalErrorText = value;
                OnPropertyChanged(nameof(TbPhysicalErrorText));
            }
        }

        private Visibility tbTouchVisibility = Visibility.Collapsed;
        public Visibility TbTouchErrorVisibility
        {
            get { return tbTouchVisibility; }
            set
            {
                tbTouchVisibility = value;
                OnPropertyChanged(nameof(TbTouchErrorVisibility));
            }
        }

        private string tbTouchErrorText;
        public string TbTouchErrorText
        {
            get { return tbTouchErrorText; }
            set
            {
                tbTouchErrorText = value;
                OnPropertyChanged(nameof(TbTouchErrorText));
            }
        }

        private Visibility tbPaceVisibility = Visibility.Collapsed;
        public Visibility TbPaceErrorVisibility
        {
            get { return tbPaceVisibility; }
            set
            {
                tbPaceVisibility = value;
                OnPropertyChanged(nameof(TbPaceErrorVisibility));
            }
        }

        private string tbPaceErrorText;
        public string TbPaceErrorText
        {
            get { return tbPaceErrorText; }
            set
            {
                tbPaceErrorText = value;
                OnPropertyChanged(nameof(TbPaceErrorText));
            }
        }

        public List<string> Validate()
        {
            TbHeightErrorVisibility = Visibility.Collapsed;
            TbWeightErrorVisibility = Visibility.Collapsed;
            TbNationalityErrorVisibility = Visibility.Collapsed;
            TbBirthdayErrorVisibility = Visibility.Collapsed;
            TbShootingErrorVisibility = Visibility.Collapsed;
            TbDribblingErrorVisibility = Visibility.Collapsed;
            TbPassingErrorVisibility = Visibility.Collapsed;
            TbPhysicalErrorVisibility = Visibility.Collapsed;
            TbTouchErrorVisibility = Visibility.Collapsed;
            TbPaceErrorVisibility = Visibility.Collapsed;

            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(Height))
            {
                errors.Add("Height is required.");
                TbHeightErrorVisibility = Visibility.Visible;
            }
            else if (!IsValidNumber(Height, out int height))
            {
                errors.Add("Height must be a number.");
                TbHeightErrorVisibility = Visibility.Visible;
            }

            if (string.IsNullOrWhiteSpace(Weight))
            {
                errors.Add("Weight is required.");
                TbWeightErrorVisibility = Visibility.Visible;
            }
            else if (!IsValidNumber(Weight, out int weight))
            {
                errors.Add("Weight must be a number.");
                TbWeightErrorVisibility = Visibility.Visible;
            }

            if (string.IsNullOrWhiteSpace(Birthday) || !IsDateValid(Birthday, out DateTime parsedDate))
            {
                errors.Add("Birthdate is required.");
                TbBirthdayErrorVisibility = Visibility.Visible;
            }

            if (string.IsNullOrWhiteSpace(Shooting))
            {
                errors.Add("Shooting is required.");
                TbShootingErrorVisibility = Visibility.Visible;
            }
            else if (!IsValidStat(Shooting))
            {
                errors.Add("Shooting must be a number between 1 and 99.");
                TbShootingErrorVisibility = Visibility.Visible;
            }

            if (string.IsNullOrWhiteSpace(Dribbling))
            {
                errors.Add("Dribbling is required.");
                TbDribblingErrorVisibility = Visibility.Visible;
            }
            else if (!IsValidStat(Dribbling))
            {
                errors.Add("Dribbling must be a number between 1 and 99.");
                TbDribblingErrorVisibility = Visibility.Visible;
            }

            if (string.IsNullOrWhiteSpace(Passing))
            {
                errors.Add("Passing is required.");
                TbPassingErrorVisibility = Visibility.Visible;
            }
            else if (!IsValidStat(Passing))
            {
                errors.Add("Passing must be a number between 1 and 99.");
                TbPassingErrorVisibility = Visibility.Visible;
            }

            if (string.IsNullOrWhiteSpace(Physical))
            {
                errors.Add("Physical is required.");
                TbPhysicalErrorVisibility = Visibility.Visible;
            }
            else if (!IsValidStat(Physical))
            {
                errors.Add("Physical must be a number between 1 and 99.");
                TbPhysicalErrorVisibility = Visibility.Visible;
            }

            if (string.IsNullOrWhiteSpace(Touch))
            {
                errors.Add("Touch is required.");
                TbTouchErrorVisibility = Visibility.Visible;
            }
            else if (!IsValidStat(Touch))
            {
                errors.Add("Touch must be a number between 1 and 99.");
                TbTouchErrorVisibility = Visibility.Visible;
            }

            if (string.IsNullOrWhiteSpace(Pace))
            {
                errors.Add("Pace is required.");
                TbPaceErrorVisibility = Visibility.Visible;
            }
            else if (!IsValidStat(Pace))
            {
                errors.Add("Pace must be a number between 1 and 99.");
                TbPaceErrorVisibility = Visibility.Visible;
            }

            return errors;
        }

        public void CreatePlayerProfile(object parameter)
        {
            List<string> errors = Validate();

            if (errors.Count == 0)
            {
                try
                {
                    DatabaseManager dbManager = new DatabaseManager();
                    dbManager.InsertPlayer(UserID, Height, Weight, Country, Birthday, Gender, Shooting, Dribbling, Passing, Physical, Touch, Pace);
                    MessageBox.Show("Player profile created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    ViewChanged?.Invoke(this, new EventArgs<string>("4"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while creating the profile: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                foreach (string error in errors)
                {
                    switch (error)
                    {
                        case "Height is required.":
                            TbHeightErrorVisibility = Visibility.Visible;
                            TbHeightErrorText = error;
                            break;
                        case "Weight is required.":
                            TbWeightErrorVisibility = Visibility.Visible;
                            TbWeightErrorText = error;
                            break;
                        case "Birthdate is required.":
                            TbBirthdayErrorVisibility = Visibility.Visible;
                            TbBirthdayErrorText = error;
                            break;
                        case "Shooting is required.":
                            TbShootingErrorVisibility = Visibility.Visible;
                            TbShootingErrorText = error;
                            break;
                        case "Dribbling is required.":
                            TbDribblingErrorVisibility = Visibility.Visible;
                            TbDribblingErrorText = error;
                            break;
                        case "Passing is required.":
                            TbPassingErrorVisibility = Visibility.Visible;
                            TbPassingErrorText = error;
                            break;
                        case "Physical is required.":
                            TbPhysicalErrorVisibility = Visibility.Visible;
                            TbPhysicalErrorText = error;
                            break;
                        case "Touch is required.":
                            TbTouchErrorVisibility = Visibility.Visible;
                            TbTouchErrorText = error;
                            break;
                        case "Pace is required.":
                            TbPaceErrorVisibility = Visibility.Visible;
                            TbPaceErrorText = error;
                            break;
                    }
                }
            }
        }

        private bool IsDateValid(string date, out DateTime parsedDate)
        {
            string[] formats = { "dd/MM/yyyy", "MM/dd/yyyy" };

            return DateTime.TryParseExact(date, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
        }

        private bool IsValidNumber(string value, out int result)
        {
            return int.TryParse(value, out result);
        }

        private bool IsValidStat(string statValue)
        {
            if (int.TryParse(statValue, out int stat))
            {
                return stat >= 0 && stat <= 99;
            }
            return false;
        }
    }
}
