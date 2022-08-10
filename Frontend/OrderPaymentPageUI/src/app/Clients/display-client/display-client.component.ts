import { Component, OnInit } from '@angular/core';
import { ClientServiceService } from 'src/app/Services/client-service.service';

@Component({
  selector: 'app-display-client',
  templateUrl: './display-client.component.html',
  styleUrls: ['./display-client.component.css']
})
export class DisplayClientComponent implements OnInit {
  public clientName:string = "";
  constructor(private clientSer:ClientServiceService) { }

  ngOnInit(): void {
    this.clientSer.get().subscribe(
      data =>{this.clientName = data.userName;},
      error => {console.log(error)}
    )
  }

}
