var app = angular.module('myapp', []);

app.controller("nhanCtrl", function ($rootScope, $scope, $http) {

    $http.get('/nhan/sanpham')
        .then(function (d) {
            $scope.listsp = d.data;
        }, function (error) {
            alert('failed');
        });


});
//app.controller('GetTTbyIDController', function ($scope, $http) {

//    $scope.loadrecord = function (id) {

//        $http.get("/ThongTin/Get_databyid?id=" + id).then(function (d) {

//            $scope.ThongTin = d.data;
//            console.log($scope.ThongTin)

//        }, function (error) {

//            alert('Failed');

//        });

//    };


//});
app.controller("DS", function ($scope, $http, $location) {
    $http.get('/LoaiSanPham/get_loaisp').then(function (d) {
        $scope.regdata = d.data;
    }, function (error) {
        alert('failed');
        console.log(d.data);
    });

});
app.controller("SPTheoLoai", function ($scope, $http, $location) {
    $http.get('/LoaiSanPham/Get_ruouvang_bymaloai').then(function (d) {
        $scope.reg = d.data;
    }, function (error) {
        alert('failed');
        console.log(d.data);
    });

});
app.controller("ctsp", function ($scope, $http, $location) {
    debugger
    $scope.loadrecord = function (id) {
        $http.get('/chitietsanpham/detail?masp=" + id')
            .then(function (d) {
                $scope.ma = d.data;
            }, function (error) {
                alert('failed');
            });
    }
});