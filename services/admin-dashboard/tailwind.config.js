/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{vue,js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        primary: '#6750A4',
        'primary-container': '#EADDFF',
        secondary: '#625B71',
        'secondary-container': '#E8DEF8',
        tertiary: '#7D5260',
        'tertiary-container': '#FFD8E4',
        error: '#B3261E',
        'error-container': '#F9DEDC',
        background: '#FFFBFE',
        'on-primary': '#FFFFFF',
        'on-primary-container': '#21005D',
        'on-secondary': '#FFFFFF',
        'on-secondary-container': '#1D192B',
        'on-tertiary': '#FFFFFF',
        'on-tertiary-container': '#31111D',
        'on-error': '#FFFFFF',
        'on-error-container': '#410E0B',
        'on-background': '#1C1B1F',
        'surface': '#FFFBFE',
        'on-surface': '#1C1B1F',
        'surface-variant': '#E7E0EC',
        'on-surface-variant': '#49454F',
        'outline': '#79747E',
      },
    },
  },
  plugins: [],
}
