﻿using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Dopamine.Core.Audio
{

    public class EqualizerPreset : BindableBase
    {
        #region Variables
        private ObservableCollection<EqualizerBand> bands;
        private string name;
        private bool isRemovable;
        #endregion

        #region Properties
        public ObservableCollection<EqualizerBand> Bands
        {
            get { return this.bands; }
            set
            {
                SetProperty<ObservableCollection<EqualizerBand>>(ref this.bands, value);
            }
        }

        public bool IsRemovable
        {
            get { return this.isRemovable; }
        }

        public string Name
        {
            get { return this.name; }
        }
        #endregion

        #region Construction
        public EqualizerPreset(string name, bool isRemovable)
        {
            this.name = name;
            this.isRemovable = isRemovable;
            this.Initialize();
        }
        #endregion

        #region Private
        private void Initialize()
        {
            var localBands = new ObservableCollection<EqualizerBand>();

            // Add 10 default bands (all at 0.0)
            for (int i = 0; i < 10; i++)
            {
                localBands.Add(new EqualizerBand("60"));
                localBands.Add(new EqualizerBand("170"));
                localBands.Add(new EqualizerBand("310"));
                localBands.Add(new EqualizerBand("600"));
                localBands.Add(new EqualizerBand("1K"));
                localBands.Add(new EqualizerBand("3K"));
                localBands.Add(new EqualizerBand("6K"));
                localBands.Add(new EqualizerBand("12K"));
                localBands.Add(new EqualizerBand("14K"));
                localBands.Add(new EqualizerBand("16K"));
            }

            this.Bands = localBands;
        }
        #endregion

        #region Public
        public void SetBandValue(int index, double value)
        {
            if (this.Bands != null && this.Bands.Count -1 >= index)
            {
                this.Bands[index].Value = value;
            }
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return this.name;
        }
        #endregion
    }
}