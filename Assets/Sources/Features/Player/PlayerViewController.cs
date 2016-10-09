public interface IPlayerController : IViewController {
}

public class PlayerViewController : ViewController, IPlayerController {
    public override void Hide(bool animated) {
        Reset();
        Assets.Destroy(gameObject);
    }
}


