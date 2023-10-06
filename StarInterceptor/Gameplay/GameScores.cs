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
        private UIPage UIPage { get; set; }

        private TextBlock ScoreBox;
        private TextBlock HullBox;
        private TextBlock GameOverBox;

        public override void Start()
        {
            UIPage = Entity.Components.Get<UIComponent>().Page;
            ScoreBox = UIPage.RootElement.FindVisualChildOfType<TextBlock>("ScoreValueText");
            HullBox = UIPage.RootElement.FindVisualChildOfType<TextBlock>("HullValueText");
            GameOverBox = UIPage.RootElement.FindVisualChildOfType<TextBlock>("GameOver");
            Score = BeginingScore;
            Hull = BeginingHull;
            // Initialization of the script.
        }

        public override void Update()
        {
            ScoreBox.Text = Score.ToString();
            HullBox.Text = Hull.ToString();

            if (Hull < 0)
            {
                GameOverBox.Visibility = Visibility.Visible;
            }
            // Do stuff every new frame
        }
    }
}
