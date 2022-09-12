/*
 * (c) Copyright 2022 Marc-Eric Boury
 */

using IrinaKuzmitskaya_pr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrinaKuzmitskaya_pr.Views {
    internal interface IModelView<TModel> : IView where TModel : IModel<TModel> {

        void Render(TModel modelInstance);
    }
}
