using Prism.Regions;
using System.Windows;
using System.Windows.Controls;

namespace BlankApp1
{
    internal class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        public StackPanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.Views.CollectionChanged += (s,e) =>
            {
                if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (UIElement item in e.NewItems)
                    {
                        regionTarget.Children.Add(item);
                    }
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new Region();
        }
    }
}
