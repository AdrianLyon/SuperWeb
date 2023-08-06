app.controller('productFormController', function ($scope, $routeParams, $location, productService) {
    $scope.product = {};

    if ($routeParams.productId) {
        // Editing existing product
        productService.getProduct($routeParams.productId)
            .then(function (response) {
                $scope.product = response.data;
            })
            .catch(function (error) {
                console.error('Error fetching product details:', error);
            });
    }

    $scope.saveProduct = function () {
        if ($routeParams.productId) {
            // Update existing product
            productService.updateProduct($routeParams.productId, $scope.product)
                .then(function () {
                    $location.path('/');
                })
                .catch(function (error) {
                    console.error('Error updating product:', error);
                });
        } else {
            // Create new product
            productService.createProduct($scope.product)
                .then(function () {
                    $location.path('/product');
                })
                .catch(function (error) {
                    console.error('Error creating product:', error);
                });
        }
    };

    $scope.deleteProduct = function () {
        productService.deleteProduct($routeParams.productId)
            .then(function () {
                $location.path('/');
            })
            .catch(function (error) {
                console.error('Error deleting product:', error);
            });
    };
});
