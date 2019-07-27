export class Store {
    constructor(public id:number,
        public storeName:string,
        public storeAddress,
        public phone:string,
        public about:string,
        public kashrutCertifiction:string,
        public img:string,
        public storeCategory:string,
        public reservedSeats:boolean,
        public club:boolean,
        public tip:boolean,
        public storeLoad:boolean,
        public bank:number,
        public brunch:number,
        public account:string){}
}
