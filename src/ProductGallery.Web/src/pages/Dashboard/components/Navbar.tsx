import { Tabs, Tab } from '@mui/material';
import AppBar from '@mui/material/AppBar/AppBar';
import React from 'react';

function Navbar({ options } : Props) {
  return (
      <AppBar component="div" position="static" elevation={0} sx={{ zIndex: 0 }}>
          <Tabs value={0} textColor="inherit">
              {options.map((label, idx) => <Tab key={idx} label={label} />)}
          </Tabs>
      </AppBar>
  );
}

type Props = {
    options: string[];
}

export default Navbar;