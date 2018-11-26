mainApp.controller('pageTitle', pageTitleCtrl);

function pageTitleCtrl($http) {
    var pageCtrl = this;

    pageCtrl.pageTitle = "loading";
        

    function successCallBack(thisdata) {
        pageCtrl.pageTitle = thisdata.DeviceName;
    }

    function errorCallBack(error) {
        pageCtrl.pageTitle = undefined;
    }
}