using System;
using Ninject.Modules;

namespace XamarinWeather.scene.home
{
    public class HomeModule : NinjectModule
    {
        private IHomeView _view;

        public HomeModule(IHomeView view)
        {
            _view = view;
        }
        public override void Load()
        {
            Bind<IHomeView>().ToConstant(_view);
            Bind<IHomeInteractor>().To<HomeInteractor>();
            //NOTE: we do not have to explicilty bind LoginPresenter 
            //since we satisfy all of its constructor's dependencies
        }
    }
}
