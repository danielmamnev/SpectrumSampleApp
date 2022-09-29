using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace SpectrumSampleApp.Core
{
    public class EntryBehaviour : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.TextChanged += Bindable_TextChanged;

        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            if (!string.IsNullOrWhiteSpace(entry.Text))
            {
                entry.Text = Regex.Replace(entry.Text, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);

            }
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= Bindable_TextChanged;
        }

    }
}
