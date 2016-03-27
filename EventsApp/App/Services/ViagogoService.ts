module eventsApp.common.services {
    export class ViagogoService {
        static $inject = ["$http"];
        
        private httpService: ng.IHttpService = null;
        private baseUrl:string = "/api/Events";

        constructor($http: ng.IHttpService) {
            this.httpService = $http;
            var self = this;
        }

        public getList(): ng.IPromise<ng.IHttpPromiseCallbackArg<any>> {

            return this.httpService.get(this.baseUrl + "/Get");
        }



    }

    export interface IViagogoService {
        getList(): ng.IPromise<ng.IHttpPromiseCallbackArg<any>>;
    }

    eventsApp.services.service("ViagogoService", ViagogoService);
}