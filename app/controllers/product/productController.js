app.controller('productListController', function ($scope, $location, productService) {
    $scope.products = [];
    $scope.currentPage = 1;
    $scope.totalPages = 0;
    $scope.searchQuery = '';
    $scope.getProducts = function() {
    productService.getProducts($scope.currentPage, 10, $scope.searchQuery).
        then(function (response)
        {
            $scope.products = response.data.items
            $scope.totalPages = response.data.totalPages;
        })
        .catch(function (error)
        {
            console.error('Error fetching product:', error)
        });
    }
    $scope.changePage = function(page) {
        if (page >= 1 && page <= $scope.totalPages) {
          $scope.currentPage = page;
          $scope.getProducts();
        }
      };
    
    $scope.getProducts();

    $scope.editProduct = function (productId) {
        $location.path('/product/edit/' + productId); // Navigate to edit page
    };

    $scope.goToCreatePage = function () {
        $location.path('/product/create'); // Navigate to create page
    };

    $scope.totalPay = function()
    {
        let total = 0;
        $scope.products.forEach(function (x){
            total += x.pricePartial
        })
        return total;
    }
});