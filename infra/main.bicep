targetScope = 'subscription'

param resourceGroupName string = 'rg-bp'
param rglocation string = 'northeurope'
param location string = 'spaincentral'

resource rg 'Microsoft.Resources/resourceGroups@2025-04-01' = {
  location: rglocation
  name: resourceGroupName
}

module monitoring './modules/monitoring.bicep' = {
  name: 'monitoring-deployment'
  scope: rg
  params: {location: location}
}

output resourceGroupId string = rg.id
