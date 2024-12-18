using LojinhaDaPaulinha.Models.Entities.Product;
using LojinhaDaPaulinha.Services.Api;
using LojinhaDaPaulinha.Services.Data;
using LojinhaDaPaulinha.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LojinhaDaPaulinha.Controllers
{
    public class ProductsController : AppController
    {
        private readonly DataService _dataService;

        protected override async Task GetInputCombos()
        {
            // This entity doesn't need Input Combos.
            await Task.CompletedTask;
        }

        public ProductsController(DataService dataService)
        {
            _dataService = dataService;
        }


        // GET: Products
        public async Task<IActionResult> Index()
        {
            var getAll = await _dataService.GetAsync<IEnumerable<IndexRowProductViewModel>>(ApiUrls.GetAllProducts);

            return ManageGetDataResponse<IEnumerable<IndexRowProductViewModel>>(getAll);
        }


        // GET: Products/5
        public async Task<IActionResult> Details(int id)
        {
            // Check given ID is valid.
            if (id < 1) return IdIsNotValid(EntityNames.Product);

            // Try get model.
            var getModel = await _dataService.GetAsync<DisplayProductViewModel>(ApiUrls.GetProductDisplay, id);

            // Resolve response.
            return ManageGetDataResponse<DisplayProductViewModel>(getModel);
        }


        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            return await ViewInput(null);
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (!ModelState.IsValid)
                return await ModelStateInvalid(model, EntityNames.Product);

            // Try create Product.
            var create = await _dataService.CreateAsync(ApiUrls.CreateProduct, model);

            // Resolve response.
            return ManageInputResponse(create);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            // Check given ID is valid.
            if (id < 1) return IdIsNotValid(EntityNames.Product);

            // Try to get model.
            var getModel = await _dataService.GetAsync<EditProductViewModel>(ApiUrls.GetProductEditModel, id);

            // Resolve response.
            return ManageGetDataResponse<EditProductViewModel>(getModel);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditProductViewModel model)
        {
            // Check given ID is valid.
            if (model.Id < 1) return IdIsNotValid(EntityNames.Product);

            if (!ModelState.IsValid)
                return await ModelStateInvalid(model, EntityNames.Product);

            // Try update Product.
            var update = await _dataService.UpdateAsync(ApiUrls.UpdateProduct, model);

            // Resolve response.
            return ManageInputResponse(update);
        }


        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return IdIsNotValid(EntityNames.Product);

            // Try get Model.
            var getModel = await _dataService.GetAsync<DisplayProductViewModel>(ApiUrls.GetProductDisplay, id);

            // Resolve response.
            return ManageGetDataResponse<DisplayProductViewModel>(getModel);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Check given ID is valid.
            if (id < 1) return IdIsNotValid(EntityNames.Product);

            // Try delete Product.
            var delete = await _dataService.DeleteAsync(ApiUrls.DeleteProduct, id);

            // Resolve response.
            return ManageDeleteResponse(delete);
        }
    }
}
