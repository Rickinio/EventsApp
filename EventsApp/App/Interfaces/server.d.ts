declare module eventsApp.models {
    export interface Event {
        Name: string;
        MinTicketPrice: Money;
        Venue: EmbeddedVenue;
        WebPageLink: Link;
        StartDate: Date;
        IsCoutryCheapest: boolean;
        IsSelected: boolean;
    }

    export interface Money {
        Amount: number;
        Currency: string;
        Display: string;
    }

    export interface EmbeddedVenue {
        City: string;
        Country: Country;
        Id: number;
        Latitude: number;
        Longitude: number;
        Name: string;
        StateProvince: string;
    }

    export interface Link {
         HRef: string;
         IsTemplated: boolean;
         Title: string;
    }

    export interface Country {
        Code: string;
        LocalWebPageLink: Link;
        Name: string;
    }
}