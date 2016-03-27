module eventsApp.common.services {
    export class ViagogoService {
        static $inject = ["$http"];
        
        private baseUrl:string = "/api/Events";

        constructor(public $http: ng.IHttpService) {
            
        }

        public getList(): ng.IPromise<ng.IHttpPromiseCallbackArg<any>> {

            return this.$http.get(this.baseUrl + "/Get");
        }
    }

    export interface IViagogoService {
        getList(): ng.IPromise<ng.IHttpPromiseCallbackArg<any>>;
    }

    eventsApp.services.service("ViagogoService", ViagogoService);
}