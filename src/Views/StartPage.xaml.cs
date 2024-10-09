namespace MauiPlanets.Views;

public sealed partial class StartPage : ContentPage
{
    public StartPage()
    {
        InitializeComponent();
    }

    private Animation? _parentAnimation;
    public Animation ParentAnimation => _parentAnimation ??= new Animation
                {
                    //Planets Animation
                    { 0, 0.2, new Animation(v => imgMercury.Opacity = v, 0, 1, Easing.CubicIn) },
                    { 0.1, 0.3, new Animation(v => imgVenus.Opacity = v, 0, 1, Easing.CubicIn) },
                    { 0.2, 0.4, new Animation(v => imgEarth.Opacity = v, 0, 1, Easing.CubicIn) },
                    { 0.3, 0.5, new Animation(v => imgMars.Opacity = v, 0, 1, Easing.CubicIn) },
                    { 0.4, 0.6, new Animation(v => imgJupiter.Opacity = v, 0, 1, Easing.CubicIn) },
                    { 0.5, 0.7, new Animation(v => imgSaturn.Opacity = v, 0, 1, Easing.CubicIn) },
                    { 0.6, 0.8, new Animation(v => imgNeptune.Opacity = v, 0, 1, Easing.CubicIn) },
                    { 0.7, 0.9, new Animation(v => imgUranus.Opacity = v, 0, 1, Easing.CubicIn) },

                    //Intro Box Animation
                    { 0.7, 1, new Animation(v => frmIntro.Opacity = v, 0, 1, Easing.CubicIn) }
                };

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (this.AnimationIsRunning("TransitionAnimation"))
            return;

        //Commit the animation
        ParentAnimation.Commit(this, "TransitionAnimation", 16, 3000, null, null);
    }

    public async void ExploreNow_Clicked(object sender, EventArgs e)
    {
        if (this.AnimationIsRunning("TransitionAnimation"))
            return;

        if (Application.Current != null && Application.Current.Windows.Count > 0)
            await MainThread.InvokeOnMainThreadAsync(() => Application.Current.Windows[0].Page = new NavigationPage(new PlanetsPage()));
    }
}
