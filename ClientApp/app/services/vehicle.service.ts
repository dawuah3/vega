import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class VehicleService {

  constructor(private http: Http) { }

  getMakes() {
    return this.http.get('/api/vehicles/makes')
      .map(res => res.json());
  }

  getFeatures() {
    return this.http.get('/api/vehicles/features')
      .map(response => response.json());
  }

  create(vehicle: any) {
    return this.http.post('/api/vehicles', vehicle)
      .map(res => res.json());
  }

  getVehicle(id: number) {
    return this.http.get('/api/vehicles/' + id)
      .map(res => res.json());
  }

  delete(id: number) {
    return this.http.delete('/api/vehicles/' + id)
      .map(res => res.json());
  }

}
