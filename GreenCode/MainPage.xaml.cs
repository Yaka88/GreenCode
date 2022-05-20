using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GreenCode
{
    public partial class MainPage : ContentPage
    {
        const string strName = "SName";
        const string strPlace = "SPlace";
        const string strFontSize = "SFontSize";
        int[] intArray = {35,50,16,14,15};
        public MainPage()
        {
            InitializeComponent();
            lblDate.Text = DateTime.Now.ToString("M");
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                lblTime.Text = DateTime.Now.ToString("T");
                return true;
            });
           
        }  
        public void saveData()
        {
            Application.Current.Properties[strName] = lblName.Text;
            Application.Current.Properties[strPlace] = lblPlace.Text;
            Application.Current.Properties[strFontSize] = sliderSize.Value;
        }
        public void resumeData()
        {
            lblDate.Text = DateTime.Now.ToString("M");
            lblName.Text = (string)Application.Current.Properties[strName];
            lblPlace.Text = (string)Application.Current.Properties[strPlace];
            sliderSize.Value = (double)Application.Current.Properties[strFontSize];
            if (lblPlace.Text.Length > 0)
                txtPlace.Opacity = 0;
            sliderSize.Opacity = 0;
        }
        void OnEntryCompleted(object sender, EventArgs e)
        {
            txtPlace.Opacity = 0;
            int intIndex = txtPlace.Text.LastIndexOf(' ');
            if (intIndex == -1)
                lblPlace.Text = txtPlace.Text;
            else
            {
                lblPlace.Text = txtPlace.Text.Substring(0, intIndex);
                lblName.Text = txtPlace.Text.Substring(intIndex);
            }
        }
        void OnEntryFocused(object sender, EventArgs e)
        {
            txtPlace.Opacity = 1;
            txtPlace.Text = "";
        }
        void OnSliderValueChanged(object sender, EventArgs e)
        {
            lblDate.FontSize = intArray[0] * sliderSize.Value;
            lblTime.FontSize = intArray[1] * sliderSize.Value;
            lblName.FontSize = intArray[2] * sliderSize.Value;  
            lblShow.FontSize = intArray[3] * sliderSize.Value;
            lblPlace.FontSize = intArray[4] * sliderSize.Value;
        }
        void OnSliderUnfocused(object sender, EventArgs e)
        {
            sliderSize.Opacity = 0;
        }
        void OnSliderFocused(object sender, EventArgs e)
        {
            sliderSize.Opacity = 1;
        }
    }
}
