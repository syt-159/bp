param resourceName string = 'bp-insights'
param workspaceName string = 'bp-law'
param location string

resource workspace 'Microsoft.OperationalInsights/workspaces@2023-09-01' = {
  name: workspaceName
  location: location
  properties: {
    sku: {
      name: 'PerGB2018'
    }
    retentionInDays: 30
  }
}

resource component 'Microsoft.Insights/components@2020-02-02' = {
  name: resourceName
  location: location
  kind: 'web'
  properties: {
    Application_Type: 'web'
    DisableIpMasking: false
    DisableLocalAuth: false
    WorkspaceResourceId: workspace.id
  }
}

output applicationInsightsId string = component.id
output workspaceId string = workspace.id

@secure()
output connectionString string = component.properties.ConnectionString
