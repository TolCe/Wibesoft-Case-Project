using System.Collections.Generic;
using System.Linq;

public class ScreenController : Singleton<ScreenController>
{
    private List<Screen> _screenList;

    protected override void Awake()
    {
        base.Awake();

        _screenList = GetComponentsInChildren<Screen>().ToList();
    }

    public Screen GetScreen(Enums.ScreenTypes type)
    {
        return _screenList.Find(x => x.ScreenType == type);
    }
}