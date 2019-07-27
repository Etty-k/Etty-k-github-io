export class Purchase {

    constructor(public id:number,
        public store:string,
        public purchaseDate:Date,
        public customerName:string,
        public customerPhone:string,
        public creditCard:string,
        public creditDate:string,
        public creditDigits:string,
        public deliveryAddress:string,
        public groupName:string,
        public reservedSeats:number,
        public club:boolean,
        public tip:boolean,
        public purchaseSum:number,
        public receiptTime:string){}
}
