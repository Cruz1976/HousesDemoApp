export interface Landlord {
  id: number;
  keyNav: string;
  fullname: string;
  address: string;
  email: string;
  mobileNumber: string;
  photoUrl: string;
}

export interface Tenant {
  id: number;
  keyNav: string;
  fullName: string;
  mobileNumber: string;
  contactNumber: string;
  email: string;
  photoUrl: string;
  tenantNote: string;
}

export interface Agreement {
  id: number;
  keyNav: string;
  dateAgreement: Date;
  startDate: Date;
  endDate: Date;
  landlords: Landlord[];
  tenants: Tenant[];
  address: string;
  rent: number;
  premises: string;
}
