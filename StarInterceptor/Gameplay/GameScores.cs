using Stride.Core;
using Stride.Engine;
using Stride.UI;
using Stride.UI.Controls;

namespace StarInterceptor.Gameplay
{
    public class GameScores : SyncScript
    {
        public int BeginingScore { get; set; }
        public int BeginingHull { get; set; }

        // Declared public member fields and properties will show in the game studio
        [DataMemberIgnore]
        public int Score { get; set; }

        [DataMemberIgnore]
        public int Hull { get; set; }
        private UIPage _uiPage { get; set; }

        private TextBlock _scoreBox;
        private TextBlock _hullBox;
        private TextBlock _gameOverBox;

        public override void Start()
        {
            _uiPage = Entity.Components.Get<UIComponent>().Page;
            _scoreBox = _uiPage.RootElement.FindVisualChildOfType<TextBlock>("ScoreValueText");
            _hullBox = _uiPage.RootElement.FindVisualChildOfType<TextBlock>("HullValueText");
            _gameOverBox = _uiPage.RootElement.FindVisualChildOfType<TextBlock>("GameOver");
            Score = BeginingScore;
            Hull = BeginingHull;
            // Initialization of the script.
        }

        public override void Update()
        {
            _scoreBox.Text = Score.ToString();
            _hullBox.Text = Hull.ToString();

            if (Hull < 0)
            {
                _gameOverBox.Visibility = Visibility.Visible;
            }
            // Do stuff every new frame
        }
    }
}
