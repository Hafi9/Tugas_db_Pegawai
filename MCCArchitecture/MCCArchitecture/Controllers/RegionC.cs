using MCCArchitecture.Models;
using MCCArchitecture.Views;

namespace MCCArchitecture.Controllers;

public class RegionC
{
    private Region _regionModel;
    private VRegion _regionView;

    public RegionC(Region regionModel, VRegion regionView)
    {
        _regionModel = regionModel;
        _regionView = regionView;
    }

    public void GetAll()
    {
        var result = _regionModel.GetAll();
        if (result.Count is 0)
        {
            _regionView.DataEmpty();
        }
        else
        {
            _regionView.GetAll(result);
        }
    }

    public void Insert()
    {
        var region = _regionView.InsertMenu();

        var result = _regionModel.Insert(region);
        switch (result)
        {
            case -1:
                _regionView.Error();
                break;
            case 0:
                _regionView.Failure();
                break;
            default:
                _regionView.Success();
                break;
        }
    }

    public void Update()
    {
        var region = _regionView.UpdateMenu();
        var result = _regionModel.Update(region);

        switch (result)
        {
            case -1:
                _regionView.Error();
                break;
            case 0:
                _regionView.Failure();
                break;
            default:
                _regionView.Success();
                break;
        }
    }
    public void SearchById()
    {
        int id = _regionView.GetRegionId();
        var result = _regionModel.GetById(id);
        if (result == null)
        {
            _regionView.RegionNotFound();
        }
        else
        {
            _regionView.GetById(result);
        }
    }

    public void Delete()
    {
        int id = _regionView.GetRegionId();
        var result = _regionModel.Delete(id);
        switch (result)
        {
            case -1:
                _regionView.Error();
                break;
            case 0:
                _regionView.Failure();
                break;
            default:
                _regionView.Success();
                break;
        }
    }
}
