import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';
import { Vehicle, KeyValuePair } from '../../models/vehicle';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {
  vehicles: Vehicle[];
  allVehicles: Vehicle[];
  makes: KeyValuePair[];
  filter: any = {};
  
    constructor(private vehicleService: VehicleService) { }
  
    ngOnInit() { 
      this.vehicleService.getMakes()
        .subscribe(makes => this.makes = makes);

      this.populateVehicles();
    }

    private populateVehicles() {
      this.vehicleService.getVehicles(this.filter)
      .subscribe(vehicles => this.vehicles = this.allVehicles = vehicles);
    }

    onFilterChange() {
      // server side filtering
      this.populateVehicles();
      
      // for clientside filtering
      // var vehicles = this.allVehicles;

      // if (this.filter.makeId)
      //   vehicles = vehicles.filter(v => v.make.id == this.filter.makeId);
      
      // if (this.filter.modelId)
      //   vehicles = vehicles.filter(v => v.model.id == this.filter.modelId);
      
      //   this.vehicles = vehicles;
    }

    resetFilter() {
      this.filter = {};
      this.onFilterChange();
    }

}
