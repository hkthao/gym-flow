export interface Customer {
  id: number
  fullName: string
  phone: string
  email: string
  gender: 'Male' | 'Female'
  membershipStatus: 'Active' | 'Inactive'
  address?: string
}