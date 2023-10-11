using StarInterceptor.Gameplay.ScoringSystem;
using StarInterceptor.Gameplay.ShipDamageSystem;
using Stride.Core;
using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.UI;
using Stride.UI.Controls;
using System.Linq;
using System;

namespace StarInterceptor.Gameplay
{
    public class GameScores : SyncScript
    {

        public ShipHullState ShipHull { get; set; }

        public Color MaxHullColor { get; set; }
        public Color MinorHullColor { get; set; }
        public Color CriticalHullColor { get; set; }

        [DataMemberIgnore]
        //public int Hull { get; set; }
        private UIPage _uiPage { get; set; }

        private TextBlock _scoreBox;
        private TextBlock _hullBox;
        private TextBlock _gameOverBox;
        private CurrentScoreState Score;

        public override void Start()
        {
            _uiPage = Entity.Components.Get<UIComponent>().Page;
            _scoreBox = _uiPage.RootElement.FindVisualChildOfType<TextBlock>("ScoreValueText");
            _hullBox = _uiPage.RootElement.FindVisualChildOfType<TextBlock>("HullValueText");
            _gameOverBox = _uiPage.RootElement.FindVisualChildOfType<TextBlock>("GameOver");
            Score = Entity.Components.Get<CurrentScoreState>();
            // Initialization of the script.
        }

        public override void Update()
        {
            _scoreBox.Text = Score.Score.ToString();

            _hullBox.Text = String.Concat(Enumerable.Repeat("|", ShipHull.CurrentHullValue));

            var hullProcentage = (float)ShipHull.CurrentHullValue / (float)ShipHull.StartingHullValue;

            if (hullProcentage >= 0.5f) _hullBox.TextColor = MinorHullColor;
            if (ShipHull.CurrentHullValue == 0 || hullProcentage < 0.5f) _hullBox.TextColor = CriticalHullColor;
            if (hullProcentage == 1) _hullBox.TextColor = MaxHullColor;

            if (ShipHull.CurrentHullValue == 0)
            {
                _gameOverBox.Visibility = Visibility.Visible;
            }
            // Do stuff every new frame
        }
    }
}
