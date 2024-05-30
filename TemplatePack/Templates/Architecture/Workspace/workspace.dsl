workspace {

    name "_WorkspaceName_"
    description "_WorkspaceDescription_"

    !adrs decisions

    model {

    }

    views {

        systemLandscape "SystemLandscape" {
            include *
        }

        styles {
            element "External" {
                background #999999
                color #ffffff
            }
            element "Database" {
                shape Cylinder
            }
        }

        theme default

    }
}