using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarjeta.Models;
using Tarjeta.Services;

namespace Tarjeta.Pages
{
    public partial class CoolEffect
    {
        [Inject]
        public BrowserService Service { get; set; }


        float innerWidth = 0;
        float innerHeight = 0;

        public CardModel CardModel { get; set; }

        public CoolEffect()
        {
            CardModel = new CardModel();
        }


        public void MouseMove(MouseEventArgs args)
        {
            var xAxis = (innerWidth / 2 - args.ScreenX) / 25;
            var yAxis = (innerHeight / 2 - args.ScreenY) / 25;
            CardModel.YRotation = yAxis;
            CardModel.XRotation = xAxis;

        }

        public void MouseOut(MouseEventArgs args)
        {
            CardModel.XRotation = 0;
            CardModel.YRotation = 0;
            CardModel.Transition = "all 0.5s ease";

            CardModel.TitleTransition = "translateZ(0px)";
            CardModel.TShirtTransition = "translateZ(0px) rotateZ(0deg)";
            CardModel.DescriptionTransition = "translateZ(0px)";
            CardModel.SizesTransition = "translateZ(0px)";
            CardModel.PurchaseTransition = "translateZ(0px)";
        }

        public void MouseOver(MouseEventArgs args)
        {
            CardModel.Transition = "none";

            CardModel.TitleTransition = "translateZ(150px)";
            CardModel.TShirtTransition = "translateZ(200px) rotateZ(-45deg)";
            CardModel.DescriptionTransition = "translateZ(125px)";
            CardModel.SizesTransition = "translateZ(100px)";
            CardModel.PurchaseTransition = "translateZ(75px)";
        }




        protected override async void OnInitialized()
        {
            base.OnInitialized();
            var dimension = await Service.GetDimensions();
            innerHeight = dimension.Height;
            innerWidth = dimension.Width;
            Console.WriteLine($"width: {innerWidth}, height: {innerHeight}");
        }

    }
}
