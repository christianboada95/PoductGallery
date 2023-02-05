import { AppBar, Toolbar, Grid, Typography } from '@mui/material';
import React from 'react';

function Title({ title } : Props) {
  return (
      <AppBar
          component="div"
          color="primary"
          position="static"
          elevation={0}
          sx={{ zIndex: 0 }}
      >
          <Toolbar>
              <Grid container alignItems="center" spacing={1}>
                  <Grid item xs>
                      <Typography color="inherit" variant="h5" component="h1">
                          {title}
                      </Typography>
                  </Grid>
              </Grid>
          </Toolbar>
      </AppBar>
  );
}

type Props = {
    title: string;
};

export default Title;