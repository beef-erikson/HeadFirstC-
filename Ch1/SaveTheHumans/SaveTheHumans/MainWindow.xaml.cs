using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace SaveTheHumans
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields

        Random random = new Random();
        DispatcherTimer enemyTimer = new DispatcherTimer();
        DispatcherTimer targetTimer = new DispatcherTimer();
        bool humanCaptured = false;

        #endregion

        #region Methods

        /// <summary>
        /// Component and timer initializations
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            enemyTimer.Tick += EnemyTimer_Tick;
            enemyTimer.Interval = TimeSpan.FromSeconds(2);

            targetTimer.Tick += TargetTimer_Tick;
            targetTimer.Interval = TimeSpan.FromSeconds(.1);
        }
        
        /// <summary>
        /// Start button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        /// <summary>
        /// Sets initial values, hides start button, adds target and human, and starts timers
        /// </summary>
        private void StartGame()
        {
            human.IsHitTestVisible = true;
            humanCaptured = false;
            progressBar.Value = 0;
            startButton.Visibility = Visibility.Collapsed;
            playArea.Children.Clear();
            playArea.Children.Add(target);
            playArea.Children.Add(human);
            enemyTimer.Start();
            targetTimer.Start();
        }

        /// <summary>
        /// Ticks target timer and advances progress bar, ending game if maximum reached
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TargetTimer_Tick(object sender, EventArgs e)
        {
            progressBar.Value += 1;
            if (progressBar.Value >= progressBar.Maximum)
            {
                EndTheGame();
            }
        }

        /// <summary>
        /// Add new enemy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnemyTimer_Tick(object sender, EventArgs e)
        {
            AddEnemy();
        }

        /// <summary>
        /// Adds enemy, starts animation and starts mouse enter handler
        /// </summary>
        private void AddEnemy()
        {
            ContentControl enemy = new ContentControl
            {
                Template = Resources["EnemyTemplate"] as ControlTemplate
            };

            AnimateEnemy(enemy, 0, playArea.ActualWidth - 100, "(Canvas.Left)");
            AnimateEnemy(enemy, random.Next((int)playArea.ActualHeight - 100),
                random.Next((int)playArea.ActualHeight - 100), "(Canvas.Top)");
            playArea.Children.Add(enemy);

            enemy.MouseEnter += Enemy_MouseEnter;
        }

        /// <summary>
        /// Animates enemy, causing it to bounce
        /// </summary>
        /// <param name="enemy">enemy content control</param>
        /// <param name="from">position to start</param>
        /// <param name="to">position to end</param>
        /// <param name="propertyToAnimate">what to animate</param>
        private void AnimateEnemy(ContentControl enemy, double from, double to, string propertyToAnimate)
        {
            Storyboard storyboard = new Storyboard() {
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever };
            DoubleAnimation animation = new DoubleAnimation() {
                From = from,
                To = to,
                Duration = new Duration(TimeSpan.FromSeconds(random.Next(4, 6))),};
            Storyboard.SetTarget(animation, enemy);
            Storyboard.SetTargetProperty(animation, new PropertyPath(propertyToAnimate));
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        /// <summary>
        /// Human is picked up by mouse down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Human_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (enemyTimer.IsEnabled)
            {
                humanCaptured = true;
                human.IsHitTestVisible = false;
            }
        }

        /// <summary>
        /// Handles the movement logic when dragging human with mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (humanCaptured)
            {
                Point pointerPosition = e.GetPosition(null);
                Point relativePosition = grid.TransformToVisual(playArea).Transform(pointerPosition);

                if ((Math.Abs(relativePosition.X - Canvas.GetLeft(human)) > human.ActualWidth * 1.2f)
                    || (Math.Abs(relativePosition.Y - Canvas.GetTop(human)) > human.ActualHeight * 1.2f))
                {
                    humanCaptured = false;
                    human.IsHitTestVisible = true;
                }
                else
                {
                    Canvas.SetLeft(human, relativePosition.X - human.ActualWidth / 2);
                    Canvas.SetTop(human, relativePosition.Y - human.ActualHeight / 2);
                }
            }
        }

        /// <summary>
        /// If human is captured when mouse enters target, 
        /// resets progress bar, respawns target/human and resets human flags
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Target_MouseEnter(object sender, MouseEventArgs e)
        {
            if (targetTimer.IsEnabled && humanCaptured)
            {
                progressBar.Value = 0;
                Canvas.SetLeft(target, random.Next(100, (int)playArea.ActualWidth - 100));
                Canvas.SetTop(target, random.Next(100, (int)playArea.ActualHeight - 100));
                Canvas.SetLeft(human, random.Next(100, (int)playArea.ActualWidth - 100));
                Canvas.SetTop(human, random.Next(100, (int)playArea.ActualHeight - 100));
                humanCaptured = false;
                human.IsHitTestVisible = true;
            }
        }

        /// <summary>
        /// Ends the game if human is captured and mouse leaves canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayArea_MouseLeave(object sender, MouseEventArgs e)
        {
            if (humanCaptured)
            {
                EndTheGame();
            }
        }

        /// <summary>
        /// If the human is captured on enemy mouse enter, end game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Enemy_MouseEnter(object sender, MouseEventArgs e)
        {
            if (humanCaptured)
            {
                EndTheGame();
            }
        }

        /// <summary>
        /// Stops timers, makes start button visiable and displays game over text
        /// </summary>
        private void EndTheGame()
        {
            if (!playArea.Children.Contains(gameOverText))
            {
                enemyTimer.Stop();
                targetTimer.Stop();
                humanCaptured = false;
                startButton.Visibility = Visibility.Visible;
                playArea.Children.Add(gameOverText);
            }
        }

        #endregion
    }
}
