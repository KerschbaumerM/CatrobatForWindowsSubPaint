﻿using System;
using Windows.System;
using Windows.UI.Xaml.Controls;
using Catrobat.IDE.Core.Services;

namespace Catrobat.IDE.Store.Services
{
    public class NavigationServicePhone : INavigationService
    {
        private Frame _frame;

        public NavigationServicePhone(Frame frame)
        {
            _frame = frame;
        }


        public void NavigateTo(Type type)
        {
            _frame.Navigate(type);
        }

        public void NavigateBack()
        {
            _frame.GoBack();
        }

        public void RemoveBackEntry()
        {
            _frame.RemoveBackEntry();
        }

        public bool CanGoBack
        {
            get { return _frame.CanGoBack; }
        }

        public void NavigateToWebPage(string uri)
        {
            Launcher.LaunchUriAsync(new Uri(uri));
        }
    }

    public static class WindowsStoreNavigationExtensions
    {
        public static void RemoveBackEntry(this Frame frame)
        {
            throw new NotImplementedException();

            // TODO: fix code below

            var parts = frame.GetNavigationState().Split(',');
            var count = Int32.Parse(parts[1]);

            if (count > 2)
            {
                int index1 = 3;

                // Find the beginning of the next-to-last entry
                for (int i = 0; i < count - 2; i++)
                    index1 = FindNextEntry(parts, index1);

                // Find the beginning of the last entry
                int index2 = FindNextEntry(parts, index1);

                // Subtract 1 from the page count and 2 from the page index
                parts[1] = (Int32.Parse(parts[1]) - 1).ToString();
                parts[2] = (Int32.Parse(parts[2]) - 2).ToString();

                // Stringify the results and navigate back two pages by calling SetNavigationState
                var state = String.Join(",", parts, 0, index1) + "," +
                            String.Join(",", parts, index2, parts.Length - index2);
                frame.SetNavigationState(state);
            }
        }

        private static int FindNextEntry(string[] entries, int index)
        {
            if (entries[index + 2] == "0")
                return index + 3;
            else if (entries[index + 3] == "0")
                return index + 4;
            else
                return index + 5;
        }
    }
}