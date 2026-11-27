targetScope = 'subscription'

param resourceGroupName string = 'rg-bp'
param rglocation string = 'northeurope'
param location string = 'spaincentral'
param appName string

resource rg 'Microsoft.Resources/resourceGroups@2025-04-01' = {
  location: rglocation
  name: resourceGroupName
}

module monitoring './modules/monitoring.bicep' = {
  name: 'monitoring-deployment'
  scope: rg
  params: { location: location }
}

module appService './modules/app-service.bicep' = {
  name: 'app-service-deployment'
  scope: rg
  params: {
    location: location
    appName: appName
    applicationInsightsConnectionString: monitoring.outputs.connectionString
  }
}

output resourceGroupId string = rg.id
