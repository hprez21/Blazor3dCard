using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarjeta.Models;

namespace Tarjeta.Comonents
{
    public partial class Card
    {
        [Parameter]
        public CardModel CardModel { get; set; }

    }
}
