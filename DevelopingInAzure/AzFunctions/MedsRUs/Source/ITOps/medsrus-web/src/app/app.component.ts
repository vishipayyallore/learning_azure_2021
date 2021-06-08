import { Component } from '@angular/core';
import { AppInsightsService } from './services/appinsights.service';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.css']
})
export class AppComponent {
	title = 'medsrus-web';

	constructor(private appInsights: AppInsightsService) {
	}

}
